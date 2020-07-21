using CustomerInvoiceManager.Entities;
using System;
using Microsoft.EntityFrameworkCore;

namespace CustomerInvoiceManager.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(LocalDb)\MSSQLLocalDB;database=CustomerInvoiceManager.DataBase;trusted_connection=true;");
        }
    }
}
