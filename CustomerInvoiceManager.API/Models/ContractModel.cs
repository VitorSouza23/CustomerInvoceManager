using CustomerInvoiceManager.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInvoiceManager.API.Models
{
    public class ContractModel
    {
        public long ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Range(1, 31)]
        public int BilingStyartDay { get; set; }

        [Required]
        public Month StartMonth { get; set; }

        [Required]
        [Range(1, 9999)]
        public int StartYear { get; set; }

        public Month? EndMotnh { get; set; }

        [Range(1, 9999)]
        public int? EndYear { get; set; }

        public double DeductibleAmount { get; set; }

        public double LateInterest { get; set; }

        public long CustomerID { get; set; }
    }
}
