using BasakWeb.Business.Abstract;
using BasakWeb.DataAccess.Abstract;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace BasakWeb.Business.Concrete
{
    public class ProductManager : IProductService
    {

        private IProductDAL _productDal;
        private ICollectionDAL _collectionDal;
        public ProductManager(IProductDAL productDal, ICollectionDAL collectionDal)
        {
            _productDal = productDal;
            _collectionDal = collectionDal;
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            //Product prd = _productDal.Get(p => p.ProductId == productId);
            _productDal.Delete(new Product {  ProductId = productId});
        }

        public List<Product> GetAll()
        {
            //EfProductDal productDal = new EfProductDal();
            //return productDal.GetList();
            //Bu şekil yapılabilir ama bu solid prensipleri açısından sıkıntılı!!!!!
            //Üst katman alt katmanı new leyemez
            //Business katmanını ef ye bağımlı hale getirmiş olduyoruz bu şekilde.
            return _productDal.GetList();
        }

    

        public List<Product> GetByCollection(int? id)
        {
            return id!=null? _productDal.GetList(p => p.Collection_Id == id).Where(d=>d.Silindi == false).ToList(): _productDal.GetList();
        }

        public Product GetbyId(int productid)
        {
           return _productDal.Get(p => p.ProductId == productid);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public IEnumerable<Product> GetLatest()
        {
            var dal = _productDal.GetList().Where(z => z.Silindi == false).OrderByDescending(x => x.DateAdded).Take(3);
            return dal;
        }

        public IEnumerable<Product> GetSimilars(int productid)
        {
            var pr = _productDal.Get(x => x.ProductId == productid);
            var dal = _productDal.GetList(x=> x.Collection_Id == pr.Collection_Id).Where(s => s.Silindi == false).Where(c=> c.ProductId != productid).OrderByDescending(x => x.DateAdded).Take(3);
            return dal;
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
