using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public  interface IResult
    {
        bool Success { get; }   //sadece okunabilir  //constructor da set edebiliyoruz // işlem basarılı mı değil mi TRUE FALSE
        string Message { get; }   //mesaj yazılacak burada da ve işlem sonucu şimdilik
    }
}
