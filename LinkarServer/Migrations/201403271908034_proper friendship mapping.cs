namespace LinkarServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class properfriendshipmapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_username", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_username" });
            RenameColumn(table: "dbo.Users", name: "User_username", newName: "friendshipId");
            CreateIndex("dbo.Users", "friendshipId");
            AddForeignKey("dbo.Users", "friendshipId", "dbo.Users", "username");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "friendshipId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "friendshipId" });
            RenameColumn(table: "dbo.Users", name: "friendshipId", newName: "User_username");
            CreateIndex("dbo.Users", "User_username");
            AddForeignKey("dbo.Users", "User_username", "dbo.Users", "username");
        }
    }
}
