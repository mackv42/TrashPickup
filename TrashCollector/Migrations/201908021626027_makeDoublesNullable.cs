namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeDoublesNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "paymentDue", c => c.Double());
            AlterColumn("dbo.Customers", "monthlyPayment", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "monthlyPayment", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "paymentDue", c => c.Double(nullable: false));
        }
    }
}
