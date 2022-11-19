using Bookworm.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Data
{
    public class ApplicationtDbContext : DbContext
    {
        public ApplicationtDbContext(DbContextOptions<ApplicationtDbContext> options) : base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Autoria> Autoria { get; set; }
        public DbSet<Classifica> Classifica {get;set;}
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Livro> Livro { get; set; }

    }
   
}
