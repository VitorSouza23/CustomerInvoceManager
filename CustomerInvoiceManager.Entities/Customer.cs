using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerInvoiceManager.Entities
{
    public class Customer
    {
        [Key]
        public long ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
