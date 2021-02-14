using Entities.Concrete;

using System.Collections.Generic;


namespace DataAccess.Abstract
{
    //interface zaten public değildir interface in operasyonları publictir  
    public interface IProductDal  //I interface demek Product hangi tabloya karsılık geldigini anlatır entity yani Dal ise hangi katmana karsılık geldiğini anlatır (Data Access Layer) Dal ya da Dao
    {
        List<Product> GetAll();        //hepsini getir          //Product la ilgili veritabanında yapılacak operasyonları içeren interface
        void Add(Product product);
        void Update(Product product);
        void delete(Product product);
        List<Product> GetAllByCategory(int categoryId);   // ürünleri kategoriye göre filtrele


    }
}

