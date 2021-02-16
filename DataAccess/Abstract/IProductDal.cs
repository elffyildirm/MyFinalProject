using Core.DataAccess;
using Entities.Concrete;

using System.Collections.Generic;


namespace DataAccess.Abstract
{
    //interface zaten public değildir interface in operasyonları publictir  
    public interface IProductDal:IEntityRepository<Product>  //I interface demek Product hangi tabloya karsılık geldigini anlatır entity yani Dal ise hangi katmana karsılık geldiğini anlatır (Data Access Layer) Dal ya da Dao
    {
      


    }
}

//Code Refactoring  kodun iyileştirilmesi