namespace QuickFix_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(),
                        Password = c.String(nullable: false, maxLength: 30),
                        Garage_GarageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId)
                .ForeignKey("dbo.Garages", t => t.Garage_GarageId, cascadeDelete: true)
                .Index(t => t.Garage_GarageId);
            
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        GarageId = c.Int(nullable: false, identity: true),
                        GarageName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Location = c.String(),
                        NumberOfEmployees = c.Int(nullable: false),
                        TinNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.GarageId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Userid = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phonenumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Userid);
            
            CreateTable(
                "dbo.servicerequireds",
                c => new
                    {
                        serviceid = c.Int(nullable: false, identity: true),
                        Servicerequired = c.String(nullable: false),
                        carmodel = c.String(nullable: false),
                        carbrand = c.String(nullable: false),
                        location = c.String(nullable: false),
                        Driver_Userid = c.Int(),
                        Garage_GarageId = c.Int(),
                    })
                .PrimaryKey(t => t.serviceid)
                .ForeignKey("dbo.Drivers", t => t.Driver_Userid)
                .ForeignKey("dbo.Garages", t => t.Garage_GarageId)
                .Index(t => t.Driver_Userid)
                .Index(t => t.Garage_GarageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.servicerequireds", "Garage_GarageId", "dbo.Garages");
            DropForeignKey("dbo.servicerequireds", "Driver_Userid", "dbo.Drivers");
            DropForeignKey("dbo.Admins", "Garage_GarageId", "dbo.Garages");
            DropIndex("dbo.servicerequireds", new[] { "Garage_GarageId" });
            DropIndex("dbo.servicerequireds", new[] { "Driver_Userid" });
            DropIndex("dbo.Admins", new[] { "Garage_GarageId" });
            DropTable("dbo.servicerequireds");
            DropTable("dbo.Drivers");
            DropTable("dbo.Garages");
            DropTable("dbo.Admins");
        }
    }
}
