namespace curator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Birthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "PublicName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PublicName", c => c.String());
            DropColumn("dbo.AspNetUsers", "BirthDate");
        }
    }
}
