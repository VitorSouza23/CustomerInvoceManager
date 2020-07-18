using CustomerInvoiceManager.Entities;
using System;
using System.Data.Entity;

namespace CustomerInvoiceManager.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
