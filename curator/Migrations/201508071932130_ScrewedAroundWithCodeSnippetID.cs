namespace curator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScrewedAroundWithCodeSnippetID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiscussionPosts", "CodeSnippet_SnippetID", "dbo.CodeSnippets");
            DropForeignKey("dbo.Ratings", "CodeSnippet_SnippetID", "dbo.CodeSnippets");
            DropIndex("dbo.DiscussionPosts", new[] { "CodeSnippet_SnippetID" });
            DropIndex("dbo.Ratings", new[] { "CodeSnippet_SnippetID" });
            DropPrimaryKey("dbo.CodeSnippets");
            DropColumn("dbo.CodeSnippets", "SnippetID");
            DropColumn("dbo.DiscussionPosts", "CodeSnippetID");
            DropColumn("dbo.Ratings", "CodeSnippetID");
            RenameColumn(table: "dbo.DiscussionPosts", name: "CodeSnippet_SnippetID", newName: "CodeSnippetID");
            RenameColumn(table: "dbo.Ratings", name: "CodeSnippet_SnippetID", newName: "CodeSnippetID");
            
            AddColumn("dbo.CodeSnippets", "CodeSnippetID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CodeSnippets", "CodeSnippetID");
            AlterColumn("dbo.DiscussionPosts", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.DiscussionPosts", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.DiscussionPosts", "BodyText", c => c.String(nullable: false));
            AlterColumn("dbo.DiscussionPosts", "CodeSnippetID", c => c.Int(nullable: false));
            AlterColumn("dbo.Ratings", "CodeSnippetID", c => c.Int(nullable: false));
            
            CreateIndex("dbo.DiscussionPosts", "CodeSnippetID");
            CreateIndex("dbo.Ratings", "CodeSnippetID");
            AddForeignKey("dbo.DiscussionPosts", "CodeSnippetID", "dbo.CodeSnippets", "CodeSnippetID", cascadeDelete: true);
            AddForeignKey("dbo.Ratings", "CodeSnippetID", "dbo.CodeSnippets", "CodeSnippetID", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.CodeSnippets", "SnippetID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Ratings", "CodeSnippetID", "dbo.CodeSnippets");
            DropForeignKey("dbo.DiscussionPosts", "CodeSnippetID", "dbo.CodeSnippets");
            DropIndex("dbo.Ratings", new[] { "CodeSnippetID" });
            DropIndex("dbo.DiscussionPosts", new[] { "CodeSnippetID" });
            DropPrimaryKey("dbo.CodeSnippets");
            AlterColumn("dbo.Ratings", "CodeSnippetID", c => c.Int());
            AlterColumn("dbo.DiscussionPosts", "CodeSnippetID", c => c.Int());
            AlterColumn("dbo.DiscussionPosts", "BodyText", c => c.String());
            AlterColumn("dbo.DiscussionPosts", "Subject", c => c.String());
            AlterColumn("dbo.DiscussionPosts", "UserName", c => c.String());
            DropColumn("dbo.CodeSnippets", "CodeSnippetID");
            AddPrimaryKey("dbo.CodeSnippets", "SnippetID");
            RenameColumn(table: "dbo.Ratings", name: "CodeSnippetID", newName: "CodeSnippet_SnippetID");
            RenameColumn(table: "dbo.DiscussionPosts", name: "CodeSnippetID", newName: "CodeSnippet_SnippetID");
            AddColumn("dbo.Ratings", "CodeSnippetID", c => c.Int(nullable: false));
            AddColumn("dbo.DiscussionPosts", "CodeSnippetID", c => c.Int(nullable: false));
            CreateIndex("dbo.Ratings", "CodeSnippet_SnippetID");
            CreateIndex("dbo.DiscussionPosts", "CodeSnippet_SnippetID");
            AddForeignKey("dbo.Ratings", "CodeSnippet_SnippetID", "dbo.CodeSnippets", "SnippetID");
            AddForeignKey("dbo.DiscussionPosts", "CodeSnippet_SnippetID", "dbo.CodeSnippets", "SnippetID");
        }
    }
}
