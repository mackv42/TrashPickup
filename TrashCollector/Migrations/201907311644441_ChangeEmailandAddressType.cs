namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmailandAddressType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address_Name", c => c.String());
            AddColumn("dbo.Customers", "Address_Street1", c => c.String());
            AddColumn("dbo.Customers", "Address_Street2", c => c.String());
            AddColumn("dbo.Customers", "Address_CityName", c => c.String());
            AddColumn("dbo.Customers", "Address_StateOrProvince", c => c.String());
            AddColumn("dbo.Customers", "Address_Country", c => c.Int());
            AddColumn("dbo.Customers", "Address_CountryName", c => c.String());
            AddColumn("dbo.Customers", "Address_Phone", c => c.String());
            AddColumn("dbo.Customers", "Address_PostalCode", c => c.String());
            AddColumn("dbo.Customers", "Address_AddressID", c => c.String());
            AddColumn("dbo.Customers", "Address_AddressOwner", c => c.Int());
            AddColumn("dbo.Customers", "Address_ExternalAddressID", c => c.String());
            AddColumn("dbo.Customers", "Address_InternationalName", c => c.String());
            AddColumn("dbo.Customers", "Address_InternationalStateAndCity", c => c.String());
            AddColumn("dbo.Customers", "Address_InternationalStreet", c => c.String());
            AddColumn("dbo.Customers", "Address_AddressStatus", c => c.Int());
            AddColumn("dbo.Customers", "Address_AddressNormalizationStatus", c => c.Int());
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String());
            DropColumn("dbo.Customers", "Address_AddressNormalizationStatus");
            DropColumn("dbo.Customers", "Address_AddressStatus");
            DropColumn("dbo.Customers", "Address_InternationalStreet");
            DropColumn("dbo.Customers", "Address_InternationalStateAndCity");
            DropColumn("dbo.Customers", "Address_InternationalName");
            DropColumn("dbo.Customers", "Address_ExternalAddressID");
            DropColumn("dbo.Customers", "Address_AddressOwner");
            DropColumn("dbo.Customers", "Address_AddressID");
            DropColumn("dbo.Customers", "Address_PostalCode");
            DropColumn("dbo.Customers", "Address_Phone");
            DropColumn("dbo.Customers", "Address_CountryName");
            DropColumn("dbo.Customers", "Address_Country");
            DropColumn("dbo.Customers", "Address_StateOrProvince");
            DropColumn("dbo.Customers", "Address_CityName");
            DropColumn("dbo.Customers", "Address_Street2");
            DropColumn("dbo.Customers", "Address_Street1");
            DropColumn("dbo.Customers", "Address_Name");
        }
    }
}
