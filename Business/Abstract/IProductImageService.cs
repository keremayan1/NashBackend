using Business.Generics;
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
    public interface IProductImageService : IGenericBaseService<ProductImage>
    {
        Task<IResult> AddAsync(List<IFormFile> file, ProductImage productImage);
        Task<IDataResult<List<ProductImage>>> GetById(int id);


    }
}
