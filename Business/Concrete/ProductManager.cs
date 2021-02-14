using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class ProductManager : IProductService //manager görünce iş katmanının somut sınıfı oldugunu anla
    {

        IProductDal _ProductDal;

        public ProductManager(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        public List<Product> GetAll()
        {

            //iş kodları
            //yetkisi var mı? v.s. gibi sorgular sorulur.


            return _ProductDal.GetAll(); // kurallardan geçince bana ürünleri verebilirsin diyor.

            //NOT business da inmemory entity framework yoktur. businessın bildiği tek sey ı product dal dır
           
           
        }
    }
}
