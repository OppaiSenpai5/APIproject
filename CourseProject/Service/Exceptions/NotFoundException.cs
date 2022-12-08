using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class NotFoundException : HttpResponseException
    {
        public NotFoundException(object? value = null) : base(404, value)
        {
        }
    }
}
