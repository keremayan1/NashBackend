using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IShopDal:IEntityRepository<Shop>,IAsyncEntityRepository<Shop>
    {
        Task<List<ShopDetailDto>> GetShopDetails(Expression<Func<ShopDetailDto, bool>> filter = null);
    }
}
