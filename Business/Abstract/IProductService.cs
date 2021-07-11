using Business.Generics;
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
   public interface IProductService:IGenericBaseService<Product>
    {
        Task<IDataResult<Product>> GetByProductId(int id);
        IDataResult<List<ProductDetailDto>>GetProductDetailsNameDesc();
        IDataResult<List<ProductDetailDto>> GetProductDetailsNameAsc();
        IDataResult<List<ProductDetailDto>> GetProductDetailsPriceAsc();
        IDataResult<List<ProductDetailDto>> GetProductDetailsPriceDesc();
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<List<ProductDetailDto>> GetProductDetailsByMinAndMaxPrice(decimal minPrice, decimal maxPrice);
        IDataResult<List<ProductDetailDto>> GetProductDetailsByCategoryNameDesc();
        IDataResult<List<ProductDetailDto>> GetProductDetailsByCategoryNameAsc();
        IDataResult<List<ProductDetailDto>> GetProductCount();





    }
}
