namespace AndreFilho.Blog.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_schema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 200, unicode: false),
                        UrlSlug = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 500, unicode: false),
                        ShortDescription = c.String(nullable: false, maxLength: 5000, unicode: false),
                        Description = c.String(nullable: false, maxLength: 5000, unicode: false),
                        Meta = c.String(nullable: false, maxLength: 1000, unicode: false),
                        SlugUrl = c.String(nullable: false, maxLength: 200, unicode: false),
                        Published = c.Boolean(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        CategoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        UrlSlug = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.PostTagMap",
                c => new
                    {
                        PostId = c.Guid(nullable: false),
                        TagId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.TagId })
                .ForeignKey("dbo.Posts", t => t.PostId)
                .ForeignKey("dbo.Tags", t => t.TagId)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostTagMap", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PostTagMap", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.PostTagMap", new[] { "TagId" });
            DropIndex("dbo.PostTagMap", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropTable("dbo.PostTagMap");
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
