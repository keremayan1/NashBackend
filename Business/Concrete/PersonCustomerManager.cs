using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonCustomerManager : IPersonCustomerService
    {
        IPersonCustomerDal _personCustomerDal;

        public PersonCustomerManager(IPersonCustomerDal personCustomerDal)
        {
            _personCustomerDal = personCustomerDal;
        }

        public async Task<IResult> AddAsync(PersonCustomer entity)
        {
            await _personCustomerDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(PersonCustomer entity)
        {
            await _personCustomerDal.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<PersonCustomer>>> GetAllAsync()
        {
            return new SuccessDataResult<List<PersonCustomer>>(await _personCustomerDal.GetAllAsync());
        }

        public async Task<IDataResult<List<PersonCustomer>>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<List<PersonCustomer>>(await _personCustomerDal.GetAllAsync(p => p.Id == id));
        }

        public async Task<IResult> UpdateAsync(PersonCustomer entity)
        {
            await _personCustomerDal.UpdateAsync(entity);
            return new SuccessResult();
        }
    }
}
