using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;
using System;

namespace Business.Concrete
{
    public class ProductManager : IProductService //manager görünce iş katmanının somut sınıfı oldugunu anla
    {

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {

            //iş kodları
            //yetkisi var mı? v.s. gibi sorgular sorulur.


            return _productDal.GetAll(); // kurallardan geçince bana ürünleri verebilirsin diyor.

            //NOT business da inmemory entity framework yoktur. businessın bildiği tek sey ı product dal dır
           
           
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
