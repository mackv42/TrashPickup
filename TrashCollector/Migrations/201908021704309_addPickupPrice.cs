namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPickupPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "pickupPrice", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "pickupPrice");
        }
    }
}
