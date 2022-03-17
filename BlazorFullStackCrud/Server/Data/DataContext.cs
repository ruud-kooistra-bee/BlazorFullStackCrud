using System.Security.Cryptography;

namespace BlazorFullStackCrud.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }

            );

            CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "user#domain.com",
                    Username = "admin",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    RoleId = 1,
                    DateOfBirth = DateTime.Now
                }, 
                new User
                {
                    Id = 2,
                    Email = "user#domain.com",
                    Username = "user",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    RoleId = 2,
                    DateOfBirth = DateTime.Now
                }
            );
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}
