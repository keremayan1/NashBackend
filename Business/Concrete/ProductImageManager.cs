﻿using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
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
        IProductService _productService;

      

        public ProductImageManager(IProductImageDal productImageDal, IProductService productService)
        {
            _productImageDal = productImageDal;
            _productService = productService;
        }
        string error = "";
        List<ProductImage> products = new List<ProductImage>();
        public async Task<IResult> Add(ProductImage productImage)
        {
            //var result = BusinessRules.Run(CheckIfProductImageEnabled(productImage), ProductImageFileCount(file, productImage));
            //if (result != null)
            //{
            //    return result;
            //}
            //await _productImageDal.MultipleAdd(products.ToArray());

            return new SuccessResult("Ürün resmi başarılı!");
        }

        public async Task<IResult> AddAsync(List<IFormFile> file, ProductImage productImage)
        {
            var result = BusinessRules.Run(CheckIfProductImageEnabled(productImage), ProductImageFileCount(file, productImage));
            if (result != null)
            {
                return result;
            }
          //  await ProductIdAdd(productImage);
            await _productImageDal.MultipleAdd(products.ToArray());
            return new SuccessResult("Ürün resmi başarılı!");
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
        //Business Rules
        private async Task ProductIdAdd(ProductImage productImage)
        {
            await _productService.Add(new Product { ProductId = productImage.ProductId });
        }
        public IResult CheckIfProductImageEnabled(ProductImage productImage)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productImage.ProductId).Count;
            if (result>=5)
            {
                return new ErrorResult("Fazla Resim Eklenildi lutfen 5'ten fazla eklemeyin");
            }
            return new SuccessResult();
        }
        public IResult ProductImageFileCount(List<IFormFile>file,ProductImage productImage)
        {
            for (int i = 0; i < file.Count; i++)
            {
                var newImage = new ProductImage
                {
                    ProductId = productImage.ProductId,
                    Date= DateTime.Now
                 
                };
                var imageResult = FileHelper.Upload(file[i]);
                if (!imageResult.Success)
                {
                    error = imageResult.Message;
                    break;
                }
                else
                {
                    newImage.ImagePath = imageResult.Message;
                    products.Add(newImage);
                }
            }
            return new SuccessResult();
        }
    
    }
}
