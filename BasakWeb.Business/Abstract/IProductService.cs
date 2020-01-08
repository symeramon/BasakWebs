using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasakWeb.Business.Abstract
{
    public interface IProductService//neden :IEntityRepository kullanmıyorum? çünkü bütün operasyonların hizmetini vermeyeceğiz daha da önemlisi, veri erişim katmanında sadece nesne ile ilgili işlemler yaparız fakat burası iş katmanı olduğu için buraya bir kural yollamak isteyebiliriz **getbycategory için konuşucak olursak...böyle bir operasyon repository'de yok! sırf kuralı kontrol için başka bir parametre yollayabiliriz yani genellikle bizim işimizi görmez. Zaten repo deseni tamamen veri erişim katmanında kullanılması gereken bir desendir.
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        Product GetbyId(int productid);
        IEnumerable<Product> GetLatest();
        void Delete(int productId);
        IEnumerable<Product> GetSimilars(int productid);
        Product GetById(int productId);
        List<Product> GetByCollection(int? id);

        //KATMANLAR ARASI İLETİŞİM ABSTRACTLAR YANİ INTERFACELER ARASINDAN OLUYOR BUNUN NEDENİ SOLİDİN D Sİ!!!!!!!!!!!!!!!! YANİ ALT KATMANLARA BAĞIMLI HALE GELMEMEK İÇİN
        //ONU İSTEYİNCE BUNU GEİTR DİYE DE STARTUPTAN AYARLIYORUZ.
    }
  
}
