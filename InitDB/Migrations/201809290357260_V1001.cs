namespace InitDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentPhotos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoType = c.Int(nullable: false),
                        PhotoUrl = c.String(nullable: false, maxLength: 500),
                        StudentId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentPhotos", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentPhotos", new[] { "StudentId" });
            DropTable("dbo.StudentPhotos");
        }
    }
}
