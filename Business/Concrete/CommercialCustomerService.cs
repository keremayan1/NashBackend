using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class CommercialCustomerService:ICommercialCustomerService
    {
        ICommercialCustomerDal _commercialCustomerDal;
        ICustomerDal _customerDal;
        public CommercialCustomerService(ICommercialCustomerDal commercialCustomerDal, ICustomerDal customerDal)
        {
            _commercialCustomerDal = commercialCustomerDal;
            _customerDal = customerDal;
        }

        public async Task<IResult> AddAsync(CommercialCustomerDetailDto commercialCustomerDetailDto)
        {
            var customer = Customer(commercialCustomerDetailDto);
            var commercialCustomer = CommercialCustomer(commercialCustomerDetailDto);
            var result = BusinessRules.Run(CheckIfCommercialCustomerExists(commercialCustomerDetailDto.TaxNumber));
            if (result!=null)
            {
                return result;
            }
            await _customerDal.AddAsync(customer);
            commercialCustomer.CustomerId = customer.CustomerId;
            await _commercialCustomerDal.AddAsync(commercialCustomer);
            return new SuccessResult();
        }

       

        public async Task<IDataResult<List<CommercialCustomer>>> GetAll()
        {
            return new SuccessDataResult<List<CommercialCustomer>>(await _commercialCustomerDal.GetAllAsync());
        }
        


        private static CommercialCustomer CommercialCustomer(CommercialCustomerDetailDto commercialCustomerDetailDto)
        {
            return new CommercialCustomer
            {
                Title = commercialCustomerDetailDto.Title,
                TaxNumber = commercialCustomerDetailDto.TaxNumber
            };
        }

        private static Customer Customer(CommercialCustomerDetailDto commercialCustomerDetailDto)
        {
            return new Customer
            {
                MusteriNo = commercialCustomerDetailDto.MusteriNo
            };
        }
        public IResult CheckIfCommercialCustomerExists(string taxNumber)
        {
            var result = _commercialCustomerDal.GetAllAsync(p => p.TaxNumber == taxNumber).Result.Any();
            if (result)
            {
                return new ErrorResult("Sistemde Kullanici Vardir");
            }
            return new SuccessResult();
        }

        public IDataResult<List<CommercialCustomerDetailDto>> GetCommercialCustomers()
        {
            return new SuccessDataResult<List<CommercialCustomerDetailDto>>(_commercialCustomerDal.GetCommercialCustomerDetails().Result);
        }
    }
}
