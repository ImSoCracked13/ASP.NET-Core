using api1.Models;

//import framework library
using Microsoft.EntityFrameworkCore;

namespace api1.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }    
    }
}
