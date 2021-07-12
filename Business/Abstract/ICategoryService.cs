
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICategoryService
    {
        Task<IDataResult<List<Category>>> GetAllAsync();
        Task<IResult> AddAsync(Category entity);
        Task<IResult> UpdateAsync(Category entity);
        Task<IResult> DeleteAsync(Category entity);
    }
}
