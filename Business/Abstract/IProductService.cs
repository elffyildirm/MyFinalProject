using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService  // interfaceleri genellikle servis olarak isimlendiririz.
    {
        List<Product> GetAll();   //list of product
        List<Product> GetAllByCategoryId(int id);    //list of product
        List<Product> GetByUnitPrice(decimal min, decimal max);   //list of product
        List<ProductDetailDto> GetProductDetails();   //list of productDetailDto
        Product GetById(int productId);    //product tek basına bir ürün döndürüyor
        IResult  Add(Product product);    //bir sey döndürmüyor   //yapmaya calıstıgın ekleme isi basarılı TRUE basarısız FALSE result da bool  //void gördüğün yere artık IResult de




    }
}
