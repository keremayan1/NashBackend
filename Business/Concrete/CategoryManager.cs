using Business.Abstract;
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

        public async Task<IResult> Add(Category entity)
        {
            await _categoryDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Category entity)
        {
            await _categoryDal.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Category>>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(await _categoryDal.GetAllAsync());
        }

        public async Task<IResult> Update(Category entity)
        {
            await _categoryDal.UpdateAsync(entity);
            return new SuccessResult();
        }
    }
}
