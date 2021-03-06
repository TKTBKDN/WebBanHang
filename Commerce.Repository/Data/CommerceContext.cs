using Commerce.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Repository.Data
{
    public class CommerceContext:DbContext
    {
        public CommerceContext(DbContextOptions<CommerceContext> options): base(options) {  }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
