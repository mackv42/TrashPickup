namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddressProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Employees", "City", c => c.String());
            AddColumn("dbo.Employees", "State", c => c.String());
            AddColumn("dbo.Employees", "Address", c => c.String());
            DropColumn("dbo.Customers", "Street");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Street", c => c.String());
            DropColumn("dbo.Employees", "Address");
            DropColumn("dbo.Employees", "State");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Customers", "City");
        }
    }
}
