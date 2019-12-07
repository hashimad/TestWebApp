namespace TestWebApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirsName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Sex = c.Int(nullable: false),
                        SaltedPassword = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        RegisteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FirsName, t.LastName }, unique: true, name: "IX_Name");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "IX_Name");
            DropTable("dbo.Users");
        }
    }
}
