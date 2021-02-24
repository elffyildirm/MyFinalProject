using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        //magic strings
        public ErrorResult(string message) : base(false, message)
        {
        }

        public ErrorResult(): base(false)
        {

        }
    }
}
