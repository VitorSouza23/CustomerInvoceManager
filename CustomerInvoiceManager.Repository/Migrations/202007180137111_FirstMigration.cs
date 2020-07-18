namespace CustomerInvoiceManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        BilingStyartDay = c.Int(nullable: false),
                        StartMonth = c.Int(nullable: false),
                        StartYear = c.Int(nullable: false),
                        EndMotnh = c.Int(),
                        EndYear = c.Int(),
                        DeductibleAmount = c.Double(nullable: false),
                        LateInterest = c.Double(nullable: false),
                        Customer_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TotalValue = c.Double(nullable: false),
                        PaidOut = c.Boolean(nullable: false),
                        Contract_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contracts", t => t.Contract_ID, cascadeDelete: true)
                .Index(t => t.Contract_ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "Contract_ID", "dbo.Contracts");
            DropIndex("dbo.Invoices", new[] { "Contract_ID" });
            DropIndex("dbo.Contracts", new[] { "Customer_ID" });
            DropTable("dbo.Customers");
            DropTable("dbo.Invoices");
            DropTable("dbo.Contracts");
        }
    }
}
