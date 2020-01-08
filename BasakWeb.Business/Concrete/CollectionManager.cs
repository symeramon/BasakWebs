using BasakWeb.Business.Abstract;
using BasakWeb.DataAccess.Abstract;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasakWeb.Business.Concrete
{
    public class CollectionManager : ICollectionService
    {
        private IProductDAL _productDal;
        private ICollectionDAL _collectionDal;
        public CollectionManager(IProductDAL productDal, ICollectionDAL collectionDal)
        {
            _productDal = productDal;
            _collectionDal = collectionDal;
        }
        public void Add(Collection collection)
        {
            _collectionDal.Add(collection);
        }
        
        public void Delete(int CollectionId)
        {
            Collection clt = _collectionDal.Get(x => x.ID == CollectionId);
            var collectionProducts = _productDal.GetList(x => x.Collection_Id == CollectionId);
            foreach (Product item in collectionProducts)
            {
                item.Silindi = true;
                _productDal.Update(item);
            }
            clt.Silindi = true;
            _collectionDal.Update(clt);
        }

        public List<Collection> GetAll()
        {
            return _collectionDal.GetCollectionListwithProducts();
        }

        public Collection GetById(int CollectionId)
        {
            return _collectionDal.Get(x => x.ID == CollectionId);
        }

        public List<Collection> GetCollections()
        {
            throw new NotImplementedException();
        }

        public void Update(Collection collection)
        {
             _collectionDal.Update(collection);
        }
    }
}
