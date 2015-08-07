namespace curator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeSNippetModded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CodeSnippets", "Language", c => c.String());
            AddColumn("dbo.CodeSnippets", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CodeSnippets", "UserName");
            DropColumn("dbo.CodeSnippets", "Language");
        }
    }
}
