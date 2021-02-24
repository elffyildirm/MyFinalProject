using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message ) : base (data,true, message)   //true işlem sonucu
        {

        }

        public SuccessDataResult(T data) : base(data,true)   //bu modellerin hepsini yapıp ne istersen verebilirsin
        {

        }
        public SuccessDataResult(string message) : base(default,true,message)
        {

        }
        public SuccessDataResult(): base (default,true)
        {

        }
    }
}
