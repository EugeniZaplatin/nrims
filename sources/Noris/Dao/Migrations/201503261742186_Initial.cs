namespace Noris.Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Status = c.Int(nullable: false),
                        Contents = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(),
                        Directory_Id = c.Guid(),
                        Version_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directories", t => t.Directory_Id)
                .ForeignKey("dbo.DirectoryVersions", t => t.Version_Id)
                .Index(t => t.Directory_Id)
                .Index(t => t.Version_Id);
            
            CreateTable(
                "dbo.Directories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        BriefDescription = c.String(),
                        FullDescription = c.String(),
                        Owner = c.String(),
                        Responser = c.String(),
                        FeedbackEmail = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(),
                        Category_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DirectoryCategories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.DirectoryCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(),
                        Parent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DirectoryCategories", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.DirectoryVersions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VersionNumber = c.String(),
                        VersionDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(),
                        Directory_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directories", t => t.Directory_Id)
                .Index(t => t.Directory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "Version_Id", "dbo.DirectoryVersions");
            DropForeignKey("dbo.DirectoryVersions", "Directory_Id", "dbo.Directories");
            DropForeignKey("dbo.Records", "Directory_Id", "dbo.Directories");
            DropForeignKey("dbo.Directories", "Category_Id", "dbo.DirectoryCategories");
            DropForeignKey("dbo.DirectoryCategories", "Parent_Id", "dbo.DirectoryCategories");
            DropIndex("dbo.DirectoryVersions", new[] { "Directory_Id" });
            DropIndex("dbo.DirectoryCategories", new[] { "Parent_Id" });
            DropIndex("dbo.Directories", new[] { "Category_Id" });
            DropIndex("dbo.Records", new[] { "Version_Id" });
            DropIndex("dbo.Records", new[] { "Directory_Id" });
            DropTable("dbo.DirectoryVersions");
            DropTable("dbo.DirectoryCategories");
            DropTable("dbo.Directories");
            DropTable("dbo.Records");
        }
    }
}
