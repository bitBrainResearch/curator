namespace curator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publicname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PublicName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PublicName");
        }
    }
}
