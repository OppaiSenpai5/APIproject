﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class HttpResponseException : Exception
    {
        public int StatusCode { get; }

        public object? Value { get; }

        public HttpResponseException(int statusCode, object? value = null)
        {
            StatusCode = statusCode;
            Value = value;
        }
    }
}
