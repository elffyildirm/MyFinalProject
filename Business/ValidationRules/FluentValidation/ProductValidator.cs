 using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
         
        }

        private bool StartWithA(string arg)  //bool true döndürürsen kurala uygun false döndürürsen kurala uygun değil demek
        {
            return arg.StartsWith("A");  //A ile baslıyorsa true döner başlamıyorsa false döner startwith patlar
        }
    }
        
        //Cross Cutting Concerns(Alttakilere bu isim verilir)
        //Log
        //Cache
        //Transaction
        //Authorization

}
