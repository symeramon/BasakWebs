using BasakWeb.Business.Abstract;
using BasakWeb.DataAccess.Abstract;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasakWeb.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDAL _categoryDal;
        public CategoryManager(ICategoryDAL categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }
    }
}
