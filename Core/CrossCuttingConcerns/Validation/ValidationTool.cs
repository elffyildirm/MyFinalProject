using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
         public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);  //parametreden gelen product için doğrulama yapacagım diyoruz
            var result = validator.Validate(context); //productValidator kullanarak ilgili contexti yani productı doğrula demek
            if (!result.IsValid)   //sonuc geçerli değilse hata alıyoruz hata fırlatma dediğimiz bir yapı söz konusu
            {
                throw new ValidationException(result.Errors);

            }
        } 
    }
}
