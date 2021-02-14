using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService  // interfaceleri genellikle servis olarak isimlendiririz.
    {
        List<Product> GetAll();



    }
}
