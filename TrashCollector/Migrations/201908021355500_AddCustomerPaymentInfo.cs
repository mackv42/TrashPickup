namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerPaymentInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "paymentDue", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "paymentDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "paymentDay");
            DropColumn("dbo.Customers", "paymentDue");
        }
    }
}
