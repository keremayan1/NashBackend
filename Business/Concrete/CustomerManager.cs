using Business.Abstract;
using Business.Adapters.PersonVerificationKps;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IPersonService _personService;
        IPersonCustomerService _personCustomerService;
        IKpsService _kpsService;

        public CustomerManager(ICustomerDal customerDal, IPersonService personService, IPersonCustomerService personCustomerService, IKpsService kpsService)
        {
            _customerDal = customerDal;
            _personService = personService;
            _personCustomerService = personCustomerService;
            _kpsService = kpsService;
        }

        public async Task<IResult> AddAsync(CustomerDetailDto customerDetailDto)
        {
            var person = Person(customerDetailDto);
            var customer = Customer(customerDetailDto);
            var result = BusinessRules.Run(CheckIfRealPerson(person), CustomerDetailsToUpper(customer),CheckIfNationalIdExists(customerDetailDto.NationalId));
            if (result != null)
            {
                return result;
            }
            await _personService.AddAsync(person);
            await _customerDal.AddAsync(customer);
            await _personCustomerService.AddAsync(new PersonCustomer { PersonId = person.Id, CustomerId = customer.CustomerId });
            return new SuccessResult("ekleme islemi basarili");
        }
        public async Task<IResult> DeleteAsync(CustomerDetailDto customerDetailDto)
        {
            var person = Person(customerDetailDto);
            var customer = Customer(customerDetailDto);
            await _personService.DeleteAsync(person);
            await  _customerDal.DeleteAsync(customer);
            await _personCustomerService.DeleteAsync(new PersonCustomer { PersonId = person.Id, CustomerId = customer.CustomerId });
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Customer>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Customer>>(await _customerDal.GetAllAsync());
        }

        public async Task<IDataResult<List<Customer>>> GetByIdAsync(int customerId)
        {
            return new SuccessDataResult<List<Customer>>(await _customerDal.GetAllAsync(p => p.CustomerId == customerId));
        }

        public   IDataResult<List<CustomerDetailDto>> GetCustomers(Customer customer)
        {
            return new SuccessDataResult<List<CustomerDetailDto>>( _customerDal.GetCustomers().Result.ToList());
        }

        public async Task<IResult> UpdateAsync(CustomerDetailDto customerDetailDto)
        {

            var person = Person(customerDetailDto);
            var customer = Customer(customerDetailDto);
            var result = BusinessRules.Run(CheckIfRealPerson(person), CustomerDetailsToUpper(customer),CheckIfNationalIdExists(customerDetailDto.NationalId));
            if (result != null)
            {
                return result;
            }
            await _personService.UpdateAsync(person);
            await _customerDal.UpdateAsync(customer);
            await _personCustomerService.UpdateAsync(new PersonCustomer { PersonId = person.Id, CustomerId = customer.CustomerId });
            return new SuccessResult();
        }
        private IResult CheckIfRealPerson(Person person)
        {
            var result = _kpsService.Verify(person).Result;
            if (result != true)
            {
                return new ErrorResult("Hatali TC-No");
            }
            return new SuccessResult();
        }
        private IResult CheckIfNationalIdExists(string nationalId)
        {
            var result = _customerDal.GetCustomers(p=>p.NationalId==nationalId).Any();
            if (result)
            {
                return new ErrorResult("Sistemde Bu Kullanıcı Mevcuttur");
            }
            return new SuccessResult();
        }
        private IResult CustomerDetailsToUpper(Customer customer)
        {
            customer.Country = customer.Country.ToUpper();
            
            return new SuccessResult();
        }
        
        private  Customer Customer(CustomerDetailDto customerDetailDto)
        {
            return new Customer
            {
                Country = customerDetailDto.Country,
                Phone = customerDetailDto.Phone
            };
        }

        private  Person Person(CustomerDetailDto customerDetailDto)
        {
            return new Person
            {
                NationalId = customerDetailDto.NationalId,
                Name = customerDetailDto.Name,
                LastName = customerDetailDto.LastName,
                DateOfBirth = customerDetailDto.DateOfBirth,
            };
        }
    }
}
