using BasakWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BasakWeb.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new()//repo deseni generic olacağı için <T> ile gösteriyoruz. T:class referans tip demek yani genel olarak class tipi olacak. IEntity yani buraya ancak veritabanı nesnesi yazabilirsin. yani ilgili t nin bir veritabanı nesnesi olması gerekiyor. new() derken abstract ve interface sışındaki classlar t olabilir demek.
    {
        T Get(Expression<Func<T, bool>> filter = null);//expressiona uygun olanları getir, hiçbirşey yazmazsam tümünü getir demek.
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
