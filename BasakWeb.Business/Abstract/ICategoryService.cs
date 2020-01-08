using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasakWeb.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();

    }
}
