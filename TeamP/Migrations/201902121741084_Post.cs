namespace TeamP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostText = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        UserName = c.String(),
                        Role = c.String(),
                        ProfilePic = c.String(),
                        UserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "ProfilePic", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
            AddColumn("dbo.AspNetUsers", "Login", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Login");
            DropColumn("dbo.AspNetUsers", "UserRole");
            DropColumn("dbo.AspNetUsers", "ProfilePic");
            DropTable("dbo.Posts");
        }
    }
}
