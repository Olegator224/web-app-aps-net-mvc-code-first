namespace web_app_asp_net_mvc_code_first.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        Data = c.Binary(nullable: false),
                        ContentType = c.String(maxLength: 100),
                        DateChanged = c.DateTime(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Errors", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ErrorTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErrorTypeErrors",
                c => new
                    {
                        ErrorType_Id = c.Int(nullable: false),
                        Error_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ErrorType_Id, t.Error_Id })
                .ForeignKey("dbo.ErrorTypes", t => t.ErrorType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Errors", t => t.Error_Id, cascadeDelete: true)
                .Index(t => t.ErrorType_Id)
                .Index(t => t.Error_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Errors", "UserId", "dbo.Users");
            DropForeignKey("dbo.ErrorTypeErrors", "Error_Id", "dbo.Errors");
            DropForeignKey("dbo.ErrorTypeErrors", "ErrorType_Id", "dbo.ErrorTypes");
            DropForeignKey("dbo.ErrorImages", "Id", "dbo.Errors");
            DropIndex("dbo.ErrorTypeErrors", new[] { "Error_Id" });
            DropIndex("dbo.ErrorTypeErrors", new[] { "ErrorType_Id" });
            DropIndex("dbo.Errors", new[] { "UserId" });
            DropIndex("dbo.ErrorImages", new[] { "Id" });
            DropTable("dbo.ErrorTypeErrors");
            DropTable("dbo.Users");
            DropTable("dbo.ErrorTypes");
            DropTable("dbo.Errors");
            DropTable("dbo.ErrorImages");
        }
    }
}
