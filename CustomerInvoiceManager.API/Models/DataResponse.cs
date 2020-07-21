using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInvoiceManager.API.Models
{
    public class DataResponse<T>
    {
        public T Value { get; set; }
        public Exception Exception { get; set; }
        public bool Ok() => Exception == null;
    }
}
