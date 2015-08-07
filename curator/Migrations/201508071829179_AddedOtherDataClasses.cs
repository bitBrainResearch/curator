namespace curator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOtherDataClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscussionPosts",
                c => new
                    {
                        DiscussionPostID = c.Int(nullable: false, identity: true),
                        CodeSnippetID = c.Int(nullable: false),
                        UserName = c.String(),
                        Subject = c.String(),
                        BodyText = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateEdited = c.DateTime(nullable: false),
                        CodeSnippet_SnippetID = c.Int(),
                    })
                .PrimaryKey(t => t.DiscussionPostID)
                .ForeignKey("dbo.CodeSnippets", t => t.CodeSnippet_SnippetID)
                .Index(t => t.CodeSnippet_SnippetID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        CodeSnippetID = c.Int(nullable: false),
                        UserName = c.String(),
                        Clarity = c.Int(nullable: false),
                        Efficiency = c.Int(nullable: false),
                        Maintainability = c.Int(nullable: false),
                        Aesthetics = c.Int(nullable: false),
                        Overall = c.Int(nullable: false),
                        CodeSnippet_SnippetID = c.Int(),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.CodeSnippets", t => t.CodeSnippet_SnippetID)
                .Index(t => t.CodeSnippet_SnippetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "CodeSnippet_SnippetID", "dbo.CodeSnippets");
            DropForeignKey("dbo.DiscussionPosts", "CodeSnippet_SnippetID", "dbo.CodeSnippets");
            DropIndex("dbo.Ratings", new[] { "CodeSnippet_SnippetID" });
            DropIndex("dbo.DiscussionPosts", new[] { "CodeSnippet_SnippetID" });
            DropTable("dbo.Ratings");
            DropTable("dbo.DiscussionPosts");
        }
    }
}
