using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerInvoiceManager.Entities
{
    public class Invoice
    {
        [Key]
        public long ID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        public double TotalValue { get; set; }

        public bool PaidOut { get; set; }

        [Required]
        public virtual Contract Contract { get; set; }

        public Invoice GenerateNextInvoiceData()
        {
            DateTime startDate = EndDate.AddDays(1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            return new Invoice
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }

    }
}
