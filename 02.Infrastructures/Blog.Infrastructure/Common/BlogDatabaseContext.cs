using Blog.Domain.Articles;
using Blog.Domain.Common.Attributes;
using Blog.Domain.Roles;
using Blog.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Blog.Infrastructure.Common
{
    public class BlogDatabaseContext : IdentityDbContext<User, Role, string>
    {
        public BlogDatabaseContext(DbContextOptions<BlogDatabaseContext> options) : base(options)
        {
        }



        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDatabaseContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditAttribute), true).Length > 0)
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    modelBuilder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
                }
            }
            modelBuilder.Entity<Article>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);



            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {

            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Added ||
                p.State == EntityState.Modified ||
                p.State == EntityState.Deleted);
            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                var inserted = entityType.FindProperty("InsertTime");
                var updated = entityType.FindProperty("UpdateTime");
                var removed = entityType.FindProperty("RemoveTime");
                var isRemoved = entityType.FindProperty("IsRemoved");
                if (item.State == EntityState.Added && inserted != null)
                    item.Property("InsertTime").CurrentValue = DateTime.Now;
                if (item.State == EntityState.Modified && updated != null)
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                if (item.State == EntityState.Deleted && removed != null && isRemoved != null)
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.Property("IsRemoved").CurrentValue = true;
                    item.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();
        }
    }
}
