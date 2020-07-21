using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInvoiceManager.API.Models
{
    public class CustomerModel
    {
        public long ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
