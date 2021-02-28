using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;
using System;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class ProductManager : IProductService //manager görünce iş katmanının somut sınıfı oldugunu anla
    {

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [ValidationAspect(typeof(ProductValidator))]   //bu yapı gidip parametreyi okuyacak productı bulup ilgili validator u bulup validation yapacak
        public IResult Add(Product product)
        {
            //business codes    //iş kuralı mesela ehliyettem 70 almışım veya kredi verirken vermeye uygun mu businessta bakılır
            //validation   //nesnenin uygun olup olmadıgını doğrulamaya denir doğrulama kaç karakter olmalı büyük küçük mü yazılmalı nesnenin yapısıyla milgili seyler validation
            //loglama kodları çalısacak
           

         _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded );  //bunu yapabilmenin yöntemi constructor eklemektir
        }

        public IDataResult <List<Product>> GetAll()
        {

            //iş kodları
            //yetkisi var mı? v.s.gibi sorgular sorulur.
            if (DateTime.Now.Hour == 1)        //her gün saat 22 de ürünleri kapatmak istiyoruz
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),  Messages.ProductsListed); // kurallardan geçince bana ürünleri verebilirsin diyor.

            //NOT business da inmemory entity framework yoktur. businessın bildiği tek sey ı product dal dır
           
           
        }

        public IDataResult < List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult < Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>( _productDal.Get(p=> p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        IDataResult<List<Product>> IProductService.GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<ProductDetailDto>> IProductService.GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
