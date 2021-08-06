using Business.Abstract;
using Business.Adapters.PersonVerificationKps;
using Core.Aspects.Autofac.Performance;
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
    public class PrivateCustomerManager : IPrivateCustomerService
    {
        IPrivateCustomerDal _privateCustomerDal;
        IKpsService _kpsService;
        ICustomerService _customerService;

        public PrivateCustomerManager(IPrivateCustomerDal privateCustomerDal, IKpsService kpsService, ICustomerService customerService)
        {
            _privateCustomerDal = privateCustomerDal;
            _kpsService = kpsService;
            _customerService = customerService;
        }

        public async Task<IResult> Add(PrivateCustomer privateCustomer)
        {
            //var result = BusinessRules.Run(VerifyId(privateCustomer));
            //if (result!=null)
            //{
            //    return result;
            //}

            await _privateCustomerDal.AddAsync(privateCustomer);
            return new SuccessResult("Basarili");
        }

        [PerformanceScopeAspect(10)]

        public async Task<IResult> Add2(PrivateCustomerDetailDto privateCustomerDetailDto)
        {

            var person = new Person
            {
                FirstName = privateCustomerDetailDto.FirstName,
                LastName = privateCustomerDetailDto.LastName,
                NationalId = privateCustomerDetailDto.NationalId,
                DateOfBirth = privateCustomerDetailDto.DateOfBirth
            };
            var result = BusinessRules.Run(VerifyId(person));
            if (result != null)
            {
                return result;
            }


            var customer = new Customer
            {
                MusteriNo = privateCustomerDetailDto.MusteriNo
            };
            await _customerService.AddAsync2(customer);

            var privateCustomer = new PrivateCustomer
            {
                Id = customer.CustomerId,
                FirstName = privateCustomerDetailDto.FirstName,
                LastName = privateCustomerDetailDto.LastName,
                NationalId = privateCustomerDetailDto.NationalId,
                DateOfBirth = privateCustomerDetailDto.DateOfBirth
            };



            await _privateCustomerDal.AddAsync(privateCustomer);


            return new SuccessResult("Basarli");



        }

        public async Task<IDataResult<List<PrivateCustomer>>> GetAll()
        {
            return new SuccessDataResult<List<PrivateCustomer>>(await _privateCustomerDal.GetAllAsync());
        }
        public IResult VerifyId(Person person)
        {
            var result = _kpsService.Verify(person).Result;
            if (!result)
            {
                return new ErrorResult("Hatali Tc");
            }
            return new SuccessResult();
        }
    }
}
