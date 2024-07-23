using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using userFavorites.Models;

namespace userFavorites
{
    public sealed class ApplicationDbContext : IdentityDbContext<AppUser,IdentityRole<Guid>,Guid>
    {

        public DbSet<StockModel> Stocks { get; set; }
        public DbSet<FavoriteModel> Favorites { get; set; }
        public DbSet<ArticleModel> Articles { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Map Identity tables to custom table names
            builder.Entity<AppUser>(entity => {
                entity.ToTable("Users");
            });

            

            builder.Entity<IdentityUserRole<Guid>>(entity => {
                entity.ToTable("UserRoles");
                entity.HasKey(r => new { r.UserId, r.RoleId });
            });

        }

    }
}
