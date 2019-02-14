namespace TeamP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "UserId" });
            DropTable("dbo.Courses");
        }
    }
}
