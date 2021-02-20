using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto      //bu bir veri tabanı tablosu değil IEntity implement edilmez join yapılır bununla
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string  CategoryName { get; set; }
        public short UnitsInStock { get; set; }

    }
}
