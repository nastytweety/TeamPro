namespace TeamP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Posts", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Posts", "UserId");
            RenameColumn(table: "dbo.Posts", name: "ApplicationUser_Id", newName: "UserId");
            AddColumn("dbo.Posts", "Login", c => c.String());
            AlterColumn("dbo.Posts", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "UserId");
            DropColumn("dbo.Posts", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UserName", c => c.String());
            DropIndex("dbo.Posts", new[] { "UserId" });
            AlterColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "Login");
            RenameColumn(table: "dbo.Posts", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "ApplicationUser_Id");
        }
    }
}
