﻿// <auto-generated />
using System;
using CustomerInvoiceManager.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerInvoiceManager.Repository.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerInvoiceManager.Entities.Contract", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BilingStyartDay")
                        .HasColumnType("int");

                    b.Property<long?>("CustomerID")
                        .HasColumnType("bigint");

                    b.Property<double>("DeductibleAmount")
                        .HasColumnType("float");

                    b.Property<int?>("EndMotnh")
                        .HasColumnType("int");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<double>("LateInterest")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("StartMonth")
                        .HasColumnType("int");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("CustomerInvoiceManager.Entities.Customer", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomerInvoiceManager.Entities.Invoice", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ContractID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PaidOut")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalValue")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("ContractID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("CustomerInvoiceManager.Entities.Contract", b =>
                {
                    b.HasOne("CustomerInvoiceManager.Entities.Customer", null)
                        .WithMany("Contracts")
                        .HasForeignKey("CustomerID");
                });

            modelBuilder.Entity("CustomerInvoiceManager.Entities.Invoice", b =>
                {
                    b.HasOne("CustomerInvoiceManager.Entities.Contract", "Contract")
                        .WithMany("Invoices")
                        .HasForeignKey("ContractID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
