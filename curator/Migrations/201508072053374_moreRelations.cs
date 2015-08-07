namespace curator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiscussionPosts", "CodeSnippet_CodeSnippetID", "dbo.CodeSnippets");
            DropForeignKey("dbo.Ratings", "CodeSnippet_CodeSnippetID", "dbo.CodeSnippets");
            DropIndex("dbo.DiscussionPosts", new[] { "CodeSnippet_CodeSnippetID" });
            DropIndex("dbo.Ratings", new[] { "CodeSnippet_CodeSnippetID" });
            RenameColumn(table: "dbo.DiscussionPosts", name: "CodeSnippet_CodeSnippetID", newName: "CodeSnippetID");
            RenameColumn(table: "dbo.Ratings", name: "CodeSnippet_CodeSnippetID", newName: "CodeSnippetID");
            AlterColumn("dbo.DiscussionPosts", "CodeSnippetID", c => c.Int(nullable: false));
            AlterColumn("dbo.Ratings", "CodeSnippetID", c => c.Int(nullable: false));
            CreateIndex("dbo.DiscussionPosts", "CodeSnippetID");
            CreateIndex("dbo.Ratings", "CodeSnippetID");
            AddForeignKey("dbo.DiscussionPosts", "CodeSnippetID", "dbo.CodeSnippets", "CodeSnippetID", cascadeDelete: true);
            AddForeignKey("dbo.Ratings", "CodeSnippetID", "dbo.CodeSnippets", "CodeSnippetID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "CodeSnippetID", "dbo.CodeSnippets");
            DropForeignKey("dbo.DiscussionPosts", "CodeSnippetID", "dbo.CodeSnippets");
            DropIndex("dbo.Ratings", new[] { "CodeSnippetID" });
            DropIndex("dbo.DiscussionPosts", new[] { "CodeSnippetID" });
            AlterColumn("dbo.Ratings", "CodeSnippetID", c => c.Int());
            AlterColumn("dbo.DiscussionPosts", "CodeSnippetID", c => c.Int());
            RenameColumn(table: "dbo.Ratings", name: "CodeSnippetID", newName: "CodeSnippet_CodeSnippetID");
            RenameColumn(table: "dbo.DiscussionPosts", name: "CodeSnippetID", newName: "CodeSnippet_CodeSnippetID");
            CreateIndex("dbo.Ratings", "CodeSnippet_CodeSnippetID");
            CreateIndex("dbo.DiscussionPosts", "CodeSnippet_CodeSnippetID");
            AddForeignKey("dbo.Ratings", "CodeSnippet_CodeSnippetID", "dbo.CodeSnippets", "CodeSnippetID");
            AddForeignKey("dbo.DiscussionPosts", "CodeSnippet_CodeSnippetID", "dbo.CodeSnippets", "CodeSnippetID");
        }
    }
}
