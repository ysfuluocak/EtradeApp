using Business.Abstract;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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

        public IResult Add(CreateCategory createCategory)
        {
            var category = new Category()
            {
                Name = createCategory.Name
            };
            _categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult Delete(CreateCategory createCategory)
        {
            var category = _categoryDal.Get(c => c.CategoryId == createCategory.CategoryId);
            _categoryDal.Delete(category);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == id));
        }

        public IResult Update(CreateCategory createCategory)
        {
            var category = _categoryDal.Get(c=>c.CategoryId==createCategory.CategoryId);
            category.Name = createCategory.Name;
            _categoryDal.Update(category);
            return new SuccessResult();
        }
    }
}
