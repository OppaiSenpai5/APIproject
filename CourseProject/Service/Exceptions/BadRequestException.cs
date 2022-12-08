using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class BadRequestException : HttpResponseException
    {
        public BadRequestException(object? value = null) : base(400, value)
        {
        }
    }
}
