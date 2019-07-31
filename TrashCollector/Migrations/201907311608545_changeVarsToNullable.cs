namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeVarsToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "pickupDay", c => c.Byte());
            AlterColumn("dbo.Customers", "suspendStart", c => c.DateTime());
            AlterColumn("dbo.Customers", "suspendEnd", c => c.DateTime());
            AlterColumn("dbo.Customers", "OneTimePickup", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "OneTimePickup", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "suspendEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "suspendStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "pickupDay", c => c.Byte(nullable: false));
        }
    }
}
