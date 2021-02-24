using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        

        public Result(bool success, string message)  // public Result(bool success, string message):this (success) yaparsak bu da calısır
        {
            Message = message;  //set et demek constructor içinde böyle set edilebilir
            // Success = success;  //dont repeat yourself  //successi set etme isini asagıdaki arkadasa veriyoruz burada yazamayız hata alıyor 
        }
        public Result(bool success)
        {
            
            Success = success;
        }

        public bool Success { get; } //sadece get oldugu için böyle implemente oldu return et demektir ne yazarsak onu return edecektir 

        public string Message { get; }
    }
}
