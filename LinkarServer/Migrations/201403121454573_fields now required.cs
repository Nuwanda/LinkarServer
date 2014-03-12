namespace LinkarServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldsnowrequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Links", "from_UserId", "dbo.Users");
            DropIndex("dbo.Links", new[] { "from_UserId" });
            AlterColumn("dbo.Links", "url", c => c.String(nullable: false));
            AlterColumn("dbo.Links", "from_UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "username", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "channelId", c => c.String(nullable: false));
            CreateIndex("dbo.Links", "from_UserId");
            AddForeignKey("dbo.Links", "from_UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "from_UserId", "dbo.Users");
            DropIndex("dbo.Links", new[] { "from_UserId" });
            AlterColumn("dbo.Users", "channelId", c => c.String());
            AlterColumn("dbo.Users", "email", c => c.String());
            AlterColumn("dbo.Users", "username", c => c.String());
            AlterColumn("dbo.Links", "from_UserId", c => c.Int());
            AlterColumn("dbo.Links", "url", c => c.String());
            CreateIndex("dbo.Links", "from_UserId");
            AddForeignKey("dbo.Links", "from_UserId", "dbo.Users", "UserId");
        }
    }
}
