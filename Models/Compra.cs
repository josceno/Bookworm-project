using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookworm.Models
{
    public class Compra
    {
        [Key()]
        public int IdCompra { get; set; }
        
        [ForeignKey("Cliente")]
        public string clienteCpf { get; set; }
        public virtual Cliente Cliente { get; set; }
        
        [ForeignKey("Livro")]
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }

        [Required]
        public double valorCompra { get; set; }
    }
}
