namespace LinkarServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddusernametoUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "username");
        }
    }
}
