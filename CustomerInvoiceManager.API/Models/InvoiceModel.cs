using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerInvoiceManager.API.Models
{
    public class InvoiceModel
    {
        public long ID { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        public double TotalValue { get; set; }

        public bool PaidOut { get; set; }

        public long ContractID { get; set; }
    }
}
