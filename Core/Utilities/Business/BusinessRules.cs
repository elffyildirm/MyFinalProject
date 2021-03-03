using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)  //params verince run içine istediğiniz kadar result verebilirsiniz parametre olarak
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)   //parametre ile gönderdiğimiz iş kuralı basarılı değilse gönder
                {
                    return logic;   //mevcut bir hata varsa o hatayı döndürür
                }
            }
            return null;     //basarılıysa bir sey göndermeye gerek yok
        }
    }
}
