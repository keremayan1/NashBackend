using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IResult> AddAsync(Category entity)
        {
            await _categoryDal.AddAsync(entity);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public async Task<IResult> DeleteAsync(Category entity)
        {
            await _categoryDal.DeleteAsync(entity);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Category>>(await _categoryDal.GetAllAsync());
        } 

        public async Task<IResult> UpdateAsync(Category entity)
        {
            await _categoryDal.UpdateAsync(entity);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
