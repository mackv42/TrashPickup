namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpaymentdue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "monthlyPayment", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "monthlyPayment");
        }
    }
}
