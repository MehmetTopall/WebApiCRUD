using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class WebApiDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlServer("Server=DESKTOP-LIMLNDB;Database=UserDB;Trusted_connection=true;");

        //public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) { }

        


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
