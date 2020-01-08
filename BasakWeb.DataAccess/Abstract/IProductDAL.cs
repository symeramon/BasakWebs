
using BasakWeb.Core.DataAccess;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasakWeb.DataAccess.Abstract
{
    public interface IProductDAL : IEntityRepository<Product>//kural solid text file hatırla!!! ayrıca product a özel view join vb sorgular operasyonlar buraya yazılacak o yüzden IEntityRepository'yi direkt çağıramıyoruz.
    //producta özel repo operasyonları olursa, IEntityRepository dışında; buraya yaz vb...

    {
        void SatildiKaldir(int orderid);
    }
}
