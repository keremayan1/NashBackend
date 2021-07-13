using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IPersonShopService
    {
        Task<IDataResult<List<PersonShop>>> GetAllAsync();
        Task<IResult> AddAsync(PersonShop entity);
        Task<IResult> UpdateAsync(PersonShop entity);
        Task<IResult> DeleteAsync(PersonShop entity);
        Task<IDataResult<List<PersonShop>>> GetByIdAsync(int id);
    }
}
