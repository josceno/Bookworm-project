using Bookworm.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Data
{
    public class ApplicationtDbContext : DbContext 
    { 
        public ApplicationtDbContext(DbContextOptions<ApplicationtDbContext> options) :base(options)
        {

        }
        public DbSet<Categoria> Categorias { get;set; }
    }
   
}
