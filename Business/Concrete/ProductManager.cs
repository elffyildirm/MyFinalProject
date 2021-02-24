using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;
using System;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class ProductManager : IProductService //manager görünce iş katmanının somut sınıfı oldugunu anla
    {

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codes
            if (product.ProductName.Length < 2)    //try catch mantıgı gibi
            {
                return new ErrorResult("Ürün ismi en az 2 karakter olmalı");
            }
            _productDal.Add(product);

            return new SuccessResult("Ürün Eklendi" );  //bunu yapabilmenin yöntemi constructor eklemektir
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

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

    }
}
