using FCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace FCommerce.DataAcsess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions option) :base(option)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
