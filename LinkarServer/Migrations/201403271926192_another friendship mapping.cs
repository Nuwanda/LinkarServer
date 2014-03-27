namespace LinkarServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherfriendshipmapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "friendshipId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "friendshipId" });
            CreateTable(
                "dbo.user_friends",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128),
                        friendID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.username, t.friendID })
                .ForeignKey("dbo.Users", t => t.username)
                .ForeignKey("dbo.Users", t => t.friendID)
                .Index(t => t.username)
                .Index(t => t.friendID);
            
            DropColumn("dbo.Users", "friendshipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "friendshipId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.user_friends", "friendID", "dbo.Users");
            DropForeignKey("dbo.user_friends", "username", "dbo.Users");
            DropIndex("dbo.user_friends", new[] { "friendID" });
            DropIndex("dbo.user_friends", new[] { "username" });
            DropTable("dbo.user_friends");
            CreateIndex("dbo.Users", "friendshipId");
            AddForeignKey("dbo.Users", "friendshipId", "dbo.Users", "username");
        }
    }
}
