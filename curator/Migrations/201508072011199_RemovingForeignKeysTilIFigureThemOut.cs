namespace curator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingForeignKeysTilIFigureThemOut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiscussionPosts", "CodeSnippetID", "dbo.CodeSnippets");
            DropForeignKey("dbo.Ratings", "CodeSnippetID", "dbo.CodeSnippets");
            DropIndex("dbo.DiscussionPosts", new[] { "CodeSnippetID" });
            DropIndex("dbo.Ratings", new[] { "CodeSnippetID" });
            RenameColumn(table: "dbo.DiscussionPosts", name: "CodeSnippetID", newName: "CodeSnippet_CodeSnippetID");
            RenameColumn(table: "dbo.Ratings", name: "CodeSnippetID", newName: "CodeSnippet_CodeSnippetID");
            AlterColumn("dbo.DiscussionPosts", "CodeSnippet_CodeSnippetID", c => c.Int());
            AlterColumn("dbo.Ratings", "CodeSnippet_CodeSnippetID", c => c.Int());
            CreateIndex("dbo.DiscussionPosts", "CodeSnippet_CodeSnippetID");
            CreateIndex("dbo.Ratings", "CodeSnippet_CodeSnippetID");
            AddForeignKey("dbo.DiscussionPosts", "CodeSnippet_CodeSnippetID", "dbo.CodeSnippets", "CodeSnippetID");
            AddForeignKey("dbo.Ratings", "CodeSnippet_CodeSnippetID", "dbo.CodeSnippets", "CodeSnippetID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "CodeSnippet_CodeSnippetID", "dbo.CodeSnippets");
            DropForeignKey("dbo.DiscussionPosts", "CodeSnippet_CodeSnippetID", "dbo.CodeSnippets");
            DropIndex("dbo.Ratings", new[] { "CodeSnippet_CodeSnippetID" });
            DropIndex("dbo.DiscussionPosts", new[] { "CodeSnippet_CodeSnippetID" });
            AlterColumn("dbo.Ratings", "CodeSnippet_CodeSnippetID", c => c.Int(nullable: false));
            AlterColumn("dbo.DiscussionPosts", "CodeSnippet_CodeSnippetID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Ratings", name: "CodeSnippet_CodeSnippetID", newName: "CodeSnippetID");
            RenameColumn(table: "dbo.DiscussionPosts", name: "CodeSnippet_CodeSnippetID", newName: "CodeSnippetID");
            CreateIndex("dbo.Ratings", "CodeSnippetID");
            CreateIndex("dbo.DiscussionPosts", "CodeSnippetID");
            AddForeignKey("dbo.Ratings", "CodeSnippetID", "dbo.CodeSnippets", "CodeSnippetID", cascadeDelete: true);
            AddForeignKey("dbo.DiscussionPosts", "CodeSnippetID", "dbo.CodeSnippets", "CodeSnippetID", cascadeDelete: true);
        }
    }
}
