using Business.Abstract;
using Business.Adapters.PersonVerificationKps;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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
        

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
           
        }
       
        public async Task<IDataResult<List<Customer>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Customer>>(await _customerDal.GetAllAsync());
        }
        [CacheAspect]
        public async Task<IDataResult<List<Customer>>> GetByIdAsync(int customerId)
        {
            return new SuccessDataResult<List<Customer>>(await _customerDal.GetAllAsync(p => p.CustomerId == customerId));
        }
      
        public async Task<IResult> AddAsync(Customer customer)
        {
            await _customerDal.AddAsync(customer);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(Customer customer)
        {
            await _customerDal.UpdateAsync(customer);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Customer customer)
        {
            await _customerDal.DeleteAsync(customer);
            return new SuccessResult();
        }
    }
}
