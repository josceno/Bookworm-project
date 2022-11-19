using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookworm.Models
{
    [Keyless]
    public class Autoria
    {
        [ForeignKey("Livro")]
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }

        [ForeignKey("Autor")]
        public int idAutor { get; set; }
        public virtual Autor Autor {get;set;} 

        public DateTime DataPublicação {get; set; }
    }
}
