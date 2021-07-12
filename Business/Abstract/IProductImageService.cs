
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService 
    {
        Task<IDataResult<List<ProductImage>>> GetAllAsync();
     
        Task<IResult> UpdateAsync(ProductImage entity);
        Task<IResult> DeleteAsync(ProductImage entity);
        Task<IResult> AddAsync(List<IFormFile> file, ProductImage productImage);
        Task<IDataResult<List<ProductImage>>> GetByIdAsync(int id);


    }
}
