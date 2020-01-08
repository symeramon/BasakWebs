using BasakWeb.Core.DataAccess;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasakWeb.DataAccess.Abstract
{
    public interface ICollectionDAL : IEntityRepository<Collection>//kural solid text file hatırla!!!
    {
        List<Collection> GetCollectionListwithProducts();
    }
}
