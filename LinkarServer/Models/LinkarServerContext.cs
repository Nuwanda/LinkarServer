using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LinkarServer.Models
{
    public class LinkarServerContext : DbContext
    {    
        public LinkarServerContext() : base("name=LinkarServerContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<LinkarServerContext, Migrations.Configuration>());
        }

        public System.Data.Entity.DbSet<LinkarServer.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<LinkarServer.Models.Link> Links { get; set; }
    
    }
}
