namespace LinkarServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedlinks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Links", "from_username", "dbo.Users");
            DropForeignKey("dbo.Users", "Link_LinkId", "dbo.Links");
            DropIndex("dbo.Links", new[] { "from_username" });
            DropIndex("dbo.Users", new[] { "Link_LinkId" });
            DropColumn("dbo.Users", "Link_LinkId");
            DropTable("dbo.Links");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        LinkId = c.Int(nullable: false, identity: true),
                        url = c.String(nullable: false),
                        from_username = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LinkId);
            
            AddColumn("dbo.Users", "Link_LinkId", c => c.Int());
            CreateIndex("dbo.Users", "Link_LinkId");
            CreateIndex("dbo.Links", "from_username");
            AddForeignKey("dbo.Users", "Link_LinkId", "dbo.Links", "LinkId");
            AddForeignKey("dbo.Links", "from_username", "dbo.Users", "username", cascadeDelete: true);
        }
    }
}
