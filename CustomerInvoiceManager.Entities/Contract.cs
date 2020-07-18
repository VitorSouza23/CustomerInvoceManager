using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerInvoiceManager.Entities
{
    public class Contract
    {
        [Key]
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

        public virtual ICollection<Invoice> Invoices { get; set; }


        public DateTime GetFirstDate() => new DateTime(StartYear, StartMonth.GetHashCode(), BilingStyartDay);

        public DateTime? GetEndDate()
        {
            if(EndMotnh.HasValue && EndYear.HasValue)
            {
                return new DateTime(EndYear.Value, EndMotnh.Value.GetHashCode(), BilingStyartDay);
            }

            return null;
        }
    }
}
