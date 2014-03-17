namespace LinkarServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeduserkeytousername : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Links", "from_UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_UserId" });
            DropIndex("dbo.Links", new[] { "from_UserId" });
            RenameColumn(table: "dbo.Users", name: "User_UserId", newName: "User_username");
            RenameColumn(table: "dbo.Links", name: "from_UserId", newName: "from_username");
            AlterColumn("dbo.Links", "from_username", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "username", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "User_username", c => c.String(maxLength: 128));
            DropPrimaryKey("dbo.Users");
            AddPrimaryKey("dbo.Users", "username");
            CreateIndex("dbo.Users", "User_username");
            CreateIndex("dbo.Links", "from_username");
            AddForeignKey("dbo.Users", "User_username", "dbo.Users", "username");
            AddForeignKey("dbo.Links", "from_username", "dbo.Users", "username", cascadeDelete: true);
            DropColumn("dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Links", "from_username", "dbo.Users");
            DropForeignKey("dbo.Users", "User_username", "dbo.Users");
            DropIndex("dbo.Links", new[] { "from_username" });
            DropIndex("dbo.Users", new[] { "User_username" });
            DropPrimaryKey("dbo.Users");
            AddPrimaryKey("dbo.Users", "UserId");
            AlterColumn("dbo.Users", "User_username", c => c.Int());
            AlterColumn("dbo.Users", "username", c => c.String(nullable: false));
            AlterColumn("dbo.Links", "from_username", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Links", name: "from_username", newName: "from_UserId");
            RenameColumn(table: "dbo.Users", name: "User_username", newName: "User_UserId");
            CreateIndex("dbo.Links", "from_UserId");
            CreateIndex("dbo.Users", "User_UserId");
            AddForeignKey("dbo.Links", "from_UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
