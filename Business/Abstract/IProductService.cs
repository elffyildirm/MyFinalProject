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
        IDataResult<List<Product>> GetAll();   //list of product  //aynı zamanda işlem sonucu ve mesajı da döndüreceğiz
        IDataResult <List<Product>> GetAllByCategoryId(int id);    //list of product
        IDataResult <List<Product>> GetByUnitPrice(decimal min, decimal max);   //list of product
        IDataResult <List<ProductDetailDto>> GetProductDetails();   //list of productDetailDto
        IDataResult <Product> GetById(int productId);    //product tek basına bir ürün döndürüyor
        IResult  Add(Product product);    //bir sey döndürmüyor   //yapmaya calıstıgın ekleme isi basarılı TRUE basarısız FALSE result da bool  //void gördüğün yere artık IResult de
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);

        //GetById de product datanın kendsi
        //data olanları Idataresult yaptık void olanı Iresult yaptık





    }
}
