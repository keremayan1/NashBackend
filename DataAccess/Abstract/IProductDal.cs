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
   public interface IProductDal:IEntityRepository<Product>,IAsyncEntityRepository<Product>
    {
        Task<List<ProductDetailDto>> GetProductDetails(Expression<Func<ProductDetailDto, bool>> filter = null);

    }
}
