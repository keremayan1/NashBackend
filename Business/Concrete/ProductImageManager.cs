using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public Task<IResult> Add(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddAsync(List<IFormFile> file, ProductImage productImage)
        {
            throw new NotImplementedException();
        }

       

        public async Task<IResult> Delete(ProductImage entity)
        {
           await _productImageDal.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<ProductImage>>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(await _productImageDal.GetAllAsync());
        }

        public async Task<IDataResult<List<ProductImage>>> GetById(int id)
        {
            return new SuccessDataResult<List<ProductImage>>(await _productImageDal.GetAllAsync(p => p.Id == id));
        }

        public async Task<IResult> Update(ProductImage entity)
        {
            await _productImageDal.UpdateAsync(entity);
            return new SuccessResult();
        }
    }
}
