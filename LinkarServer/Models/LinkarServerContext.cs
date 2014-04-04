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
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<LinkarServerContext, Migrations.Configuration>());
            modelBuilder.Entity<User>()
                .HasMany(u => u.friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("username");
                    m.MapRightKey("friendID");
                    m.ToTable("user_friends");
                });
        }

        public System.Data.Entity.DbSet<LinkarServer.Models.User> Users { get; set; }
    
    }
}
