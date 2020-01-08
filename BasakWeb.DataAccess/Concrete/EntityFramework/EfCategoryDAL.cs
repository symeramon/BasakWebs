
using BasakWeb.Core.DataAccess.EntityFramework;
using BasakWeb.DataAccess.Abstract;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasakWeb.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDAL : EfEntityRepositoryBase<Category, BasakWebContext>, ICategoryDAL
    {

    }
}
