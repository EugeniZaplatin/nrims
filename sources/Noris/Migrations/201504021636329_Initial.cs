namespace Noris.Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.record",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(nullable: false),
                        code = c.String(nullable: false),
                        status = c.Int(nullable: false),
                        contents = c.String(),
                        created_date = c.DateTime(nullable: false),
                        modified_date = c.DateTime(nullable: false),
                        deleted_date = c.DateTime(),
                        Directory_Id = c.Guid(),
                        directory_version_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.directory", t => t.Directory_Id)
                .ForeignKey("dbo.directory_version", t => t.directory_version_id, cascadeDelete: true)
                .Index(t => t.Directory_Id)
                .Index(t => t.directory_version_id);
            
            CreateTable(
                "dbo.directory",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(nullable: false),
                        xml_structure = c.String(nullable: false),
                        brief_bescription = c.String(),
                        full_description = c.String(),
                        owner = c.String(),
                        responser = c.String(),
                        feedback_email = c.String(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        modified_date = c.DateTime(nullable: false),
                        deleted_date = c.DateTime(),
                        category_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.directory_category", t => t.category_id, cascadeDelete: true)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.directory_category",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        modified_date = c.DateTime(nullable: false),
                        deleted_date = c.DateTime(),
                        parent_id = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.directory_category", t => t.parent_id)
                .Index(t => t.parent_id);
            
            CreateTable(
                "dbo.directory_version",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        version_number = c.String(),
                        version_date = c.DateTime(nullable: false),
                        description = c.String(),
                        created_date = c.DateTime(nullable: false),
                        modified_date = c.DateTime(nullable: false),
                        deleted_date = c.DateTime(),
                        category_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.directory", t => t.category_id, cascadeDelete: true)
                .Index(t => t.category_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.record", "directory_version_id", "dbo.directory_version");
            DropForeignKey("dbo.directory_version", "category_id", "dbo.directory");
            DropForeignKey("dbo.record", "Directory_Id", "dbo.directory");
            DropForeignKey("dbo.directory", "category_id", "dbo.directory_category");
            DropForeignKey("dbo.directory_category", "parent_id", "dbo.directory_category");
            DropIndex("dbo.directory_version", new[] { "category_id" });
            DropIndex("dbo.directory_category", new[] { "parent_id" });
            DropIndex("dbo.directory", new[] { "category_id" });
            DropIndex("dbo.record", new[] { "directory_version_id" });
            DropIndex("dbo.record", new[] { "Directory_Id" });
            DropTable("dbo.directory_version");
            DropTable("dbo.directory_category");
            DropTable("dbo.directory");
            DropTable("dbo.record");
        }
    }
}
