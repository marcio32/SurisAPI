using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Semilla de datos para servicios
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Corte de cabello", Price = 15.99m },
                new Service { Id = 2, Name = "Manicure", Price = 12.50m }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            // 🔹 Crear usuario por defecto
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "marcio",
                NormalizedUserName = "MARCIO",
                Email = "marcioabriola@gmail.com",
                NormalizedEmail = "MARCIOABRIOLA@GMAIL.COM",
                EmailConfirmed = true
            };
            user.PasswordHash = hasher.HashPassword(user, "1234");

            var role = new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            var userRole = new IdentityUserRole<string>
            {
                UserId = "1",
                RoleId = "1"
            };

            modelBuilder.Entity<ApplicationUser>().HasData(user);
            modelBuilder.Entity<IdentityRole>().HasData(role);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRole);
        }
    }
}
