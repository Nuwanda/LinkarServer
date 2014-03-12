namespace LinkarServer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LinkarServer.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LinkarServer.Models.LinkarServerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LinkarServer.Models.LinkarServerContext context)
        {
            context.Users.AddOrUpdate(
                u => u.UserId,
                new User { UserId = 1, username = "teste1", email = "teste1@gmail.com", channelId="asdasdasd1313132"},
                new User { UserId = 2, username = "teste2", email = "teste2@gmail.com", channelId = "asdaqweqwesd1313132" }
            );
        }
    }
}
