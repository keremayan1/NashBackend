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

      

        [PerformanceScopeAspect(5)]

        public async Task<IResult> AddAsync(PrivateCustomerDetailDto privateCustomerDetailDto)
        {
            var customer = Customer(privateCustomerDetailDto);
            var privateCustomer = PrivateCustomer(privateCustomerDetailDto);
            var result = BusinessRules.Run(CheckIfPrivateCustomerExists(privateCustomerDetailDto.NationalId));
            if (result != null)
            {
                return result;
            }
            await _customerService.AddAsync(customer);
            privateCustomer.Id = customer.CustomerId;
            await _privateCustomerDal.AddAsync(privateCustomer);
            return new SuccessResult("Basarli");
        }

        private static PrivateCustomer PrivateCustomer(PrivateCustomerDetailDto privateCustomerDetailDto)
        {
            return new PrivateCustomer
            {

                FirstName = privateCustomerDetailDto.FirstName,
                LastName = privateCustomerDetailDto.LastName,
                NationalId = privateCustomerDetailDto.NationalId,
                DateOfBirth = privateCustomerDetailDto.DateOfBirth
            };
        }

        private static Customer Customer(PrivateCustomerDetailDto privateCustomerDetailDto)
        {
            return new Customer
            {
                MusteriNo = privateCustomerDetailDto.MusteriNo
            };
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
        public IResult CheckIfPrivateCustomerExists(string nationalId)
        {
            var result = _privateCustomerDal.GetAll(pc => pc.NationalId == nationalId).Any();
            if (result)
            {
                return new ErrorResult("Kullanici Sistemde Mevcut");
            }
            return new SuccessResult();
        }
    }
}
