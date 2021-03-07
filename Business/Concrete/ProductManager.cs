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
using System.Linq;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{    //bir entitymanager kendisi hariç baska dalı enjekte edemez 
    public class ProductManager : IProductService //manager görünce iş katmanının somut sınıfı oldugunu anla
    {

        IProductDal _productDal;
        ICategoryService _categoryService;


        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
                 
        }

        //claim iddia etmek

        //[SecuredOperation("product.add,admin")]    //yetkilendirme bunu kapatınca devreye girmez
        [ValidationAspect(typeof(ProductValidator))]   //bu yapı gidip parametreyi okuyacak productı bulup ilgili validator u bulup validation yapacak
        public IResult Add(Product product)
        {   //Aynı isimde ürün eklenemez
            //Eğer mevcut kategori sayısı 15i geçtiyse siteme yeni ürün eklenemez.  

           IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),  //İş kurallarını burada gönderdik
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());
            if(result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);  //bunu yapabilmenin yöntemi constructor eklemektir
        }

        [CacheAspect]  //key,value
        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //yetkisi var mı? v.s.gibi sorgular sorulur.
            if (DateTime.Now.Hour == 1)        //her gün saat 22 de ürünleri kapatmak istiyoruz
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed); // kurallardan geçince bana ürünleri verebilirsin diyor.

            //NOT business da inmemory entity framework yoktur. businessın bildiği tek sey ı product dal dır
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(message: Messages.ProductCountOfCategoryError);
            }

            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)      //categorideki ürün sayısının kurallara uygunlugunu doğrula
        {
            //Select count(*) from products where categoryId=1 
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult( Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)      //categorideki ürün sayısının kurallara uygunlugunu doğrula
        {
          
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result )
            {
                return new ErrorResult(message: Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        IDataResult<List<Product>> IProductService.GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<ProductDetailDto>> IProductService.GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
    }
}