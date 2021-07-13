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
    public class PersonShopManager : IPersonShopService
    {
        IPersonShopDal _personShopDal;

        public PersonShopManager(IPersonShopDal personShopDal)
        {
            _personShopDal = personShopDal;
        }

        public async Task<IResult> AddAsync(PersonShop entity)
        {
          await  _personShopDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(PersonShop entity)
        {
            await _personShopDal.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<PersonShop>>> GetAllAsync()
        {
            return new SuccessDataResult<List<PersonShop>>(await _personShopDal.GetAllAsync());
        }

        public async Task<IDataResult<List<PersonShop>>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<List<PersonShop>>(await _personShopDal.GetAllAsync(ps => ps.Id == id));
        }

        public async Task<IResult> UpdateAsync(PersonShop entity)
        {
            await _personShopDal.UpdateAsync(entity);
            return new SuccessResult();
        }
    }
}
