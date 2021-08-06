using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        private ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductValidator))]

        public async Task<IResult> AddAsync(Product product)
        {
            var result = BusinessRules.Run(ProductsToUpper(product),CheckIfCategoryLimitExists(),CheckIfProductIdExists(product.ProductId));
            if (result != null)
            {
                return result;
            }
            await _productDal.AddAsync(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(Product product)
        {
            await _productDal.DeleteAsync(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        [CacheAspect]
       // [SecuredOperation("user,moderator,admin")]
        public async Task<IDataResult<List<Product>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Product>>(await _productDal.GetAllAsync(), Messages.ProductFiltered);
        }

        public async Task<IDataResult<Product>> GetByProductIdAsync(int productId)
        {
            return new SuccessDataResult<Product>(await _productDal.GetAsync(p => p.ProductId == productId));
        }

        public async Task<IResult> UpdateAsync(Product product)
        {
            await _productDal.UpdateAsync(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        public IDataResult<List<ProductDetailDto>> GetProductDetailsNameDesc()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails().Result.OrderByDescending(c => c.ProductName).ToList());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailsNameAsc()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails().Result.OrderBy(p => p.ProductName).ToList());
        }
        public  IDataResult<List<ProductDetailDto>> GetProductDetailsPriceAsc()
        {
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails().Result.OrderBy(p => p.UnitPrice).ToList());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailsPriceDesc()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails().Result.OrderByDescending(p => p.UnitPrice).ToList());
        }
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails().Result);
        }
        public IDataResult<List<ProductDetailDto>> GetProductDetailsByMinAndMaxPrice(decimal minPrice, decimal maxPrice)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice).Result);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailsByCategoryNameDesc()
        {
           
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails().Result.OrderByDescending(p => p.CategoryName).ToList());
        }

        public  IDataResult<List<ProductDetailDto>> GetProductDetailsByCategoryNameAsc()
        {
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails().Result.OrderBy(p => p.CategoryName).ToList());
        }
        public IDataResult<List<ProductDetailDto>> GetProductCount()
        {
            var result = _productDal.GetProductDetails().Result.Count.ToString();

            return new SuccessDataResult<List<ProductDetailDto>>(result);
        }

        //Business Rules
        public IResult ProductsToUpper(Product product)
        {
            product.ProductName = product.ProductName.ToUpper();
            return new SuccessResult();
        }
       
        public IResult CheckIfProductIdExists(int productId)
        {
            var result = _productDal.GetAll(p => p.ProductId == productId).Any();
            if (result)
            {
                return new ErrorResult("Bu ürün sistemde mevcut");
            }
            return new SuccessResult();
        }

        public IResult CheckIfCategoryLimitExists()
        {
            var result = _categoryService.GetAllAsync().Result.Data;
            if (result.Count>10)
            {
                return  new ErrorResult();
            }
            return  new SuccessResult();
        }

     
    }
}
