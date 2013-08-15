namespace Notechest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrganizationID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID, cascadeDelete: true)
                .Index(t => t.OrganizationID);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrganizationID = c.Int(),
                        ProjectID = c.Int(),
                        Title = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        Tags = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.OrganizationID)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Notes", new[] { "ProjectID" });
            DropIndex("dbo.Notes", new[] { "OrganizationID" });
            DropIndex("dbo.Projects", new[] { "OrganizationID" });
            DropForeignKey("dbo.Notes", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Notes", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Projects", "OrganizationID", "dbo.Organizations");
            DropTable("dbo.Notes");
            DropTable("dbo.Projects");
            DropTable("dbo.Organizations");
        }
    }
}
