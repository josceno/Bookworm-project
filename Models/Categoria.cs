using System.ComponentModel.DataAnnotations;

namespace Bookworm.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descrição { get; set; }
        public DateTime Datacriacao { get; set; } = DateTime.Now;



    }
}
