namespace CardOneMoney.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetupCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        TelephoneNumber = c.String(),
                        DateApplied = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_Customer");
        }
    }
}
