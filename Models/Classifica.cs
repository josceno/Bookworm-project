using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookworm.Models
{
    public class Classifica
    {
        [ForeignKey("Livro")]
        public int idLivro {get; set;}
        public virtual Livro Livro { get; set; }

        [ForeignKey("Categoria")]
        public int idCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }    
        
    }
}
