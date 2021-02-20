using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    //entity microsoftun bir ürünüdür linq destekli çalışır. Amaç şu veritabanındaki tabloyu sanki classmış gibi onunla ilişkilendirip sql leri linq ile yaptıgımız bir ortam. yani kodları veritabanı ile ilişkilendirme
    // NuGet kodların ortak koyulduğu yer 
    // entity framework paket adıdır
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal  //Iproduct dala diyor ki istediğin her sey EfEntityrepositoryBase içinde varben bu arkasasımı cözersem herkes mutlu olacak
    {                      //suan tüm veritabanı operasyonlarını yazmaya hazırız
        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
 