using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShopService
    {
        Task<IDataResult<List<Shop>>> GetAllAsync();
        Task<IDataResult<List<Shop>>> GetByShopIdAsync(int id);
        Task<IResult> AddAsync(ShopDetailDto shopDetailDto);
        Task<IResult> UpdateAsync(ShopDetailDto shopDetailDto);
        Task<IResult> DeleteAsync(ShopDetailDto shopDetailDto);
        IDataResult<List<ShopDetailDto>> GetShops(Shop shop);

    }
}
