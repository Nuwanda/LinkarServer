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
                u => u.username,
                new User { username = "teste1", email = "teste1@gmail.com", channelId="asdasdasd1313132"},
                new User { username = "teste2", email = "teste2@gmail.com", channelId="asdaqweqwesd1313132" },
                new User { username = "teste3", email = "teste3@gmail.com", channelId="asdqweqeqwewqeqw131232" }
            );
        }
    }
}
