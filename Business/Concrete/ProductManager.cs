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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductValidator))]
        
        public async Task<IResult> Add(Product product)
        {
            var result = BusinessRules.Run(ProductsToUpper(product));
            if (result != null)
            {
                return result;
            }
            await _productDal.AddAsync(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> Delete(Product product)
        {
            await _productDal.DeleteAsync(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        [CacheAspect]
      [SecuredOperation("user,moderator,admin")]
    
      
        public async Task<IDataResult<List<Product>>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(await _productDal.GetAllAsync(), Messages.ProductFiltered);
        }

        public async Task<IDataResult<Product>> GetByProductId(int productId)
        {
            return new SuccessDataResult<Product>(await _productDal.GetAsync(p => p.ProductId == productId));
        }

        public async Task<IResult> Update(Product product)
        {
            await _productDal.UpdateAsync(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        //Business Rules
        public IResult ProductsToUpper(Product product)
        {
            product.ProductName = product.ProductName.ToUpper();
            return new SuccessResult();
        }
     
         
    }
}
