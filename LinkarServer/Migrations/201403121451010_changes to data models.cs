namespace LinkarServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestodatamodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        LinkId = c.Int(nullable: false, identity: true),
                        url = c.String(),
                        from_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.LinkId)
                .ForeignKey("dbo.Users", t => t.from_UserId)
                .Index(t => t.from_UserId);
            
            AddColumn("dbo.Users", "Link_LinkId", c => c.Int());
            CreateIndex("dbo.Users", "Link_LinkId");
            AddForeignKey("dbo.Users", "Link_LinkId", "dbo.Links", "LinkId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Link_LinkId", "dbo.Links");
            DropForeignKey("dbo.Links", "from_UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Link_LinkId" });
            DropIndex("dbo.Links", new[] { "from_UserId" });
            DropColumn("dbo.Users", "Link_LinkId");
            DropTable("dbo.Links");
        }
    }
}
