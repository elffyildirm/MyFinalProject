using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>  //Dataresulta sen bir resultsın diyoruz result interface değil classtır
    {
        public DataResult(T data, bool success, string message):base (success,message)   //contructorlar açmamız gererkiyor madem result  // result voidler için data resultlar datalar için
        {                                               //base e de success ve mesajı gönder
            Data = data;
        }
        public DataResult(T data, bool success):base(success)
        {
            Data = data; 
        }
        public T Data { get; }
    }
}
