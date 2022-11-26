using System.ComponentModel.DataAnnotations;


namespace Bookworm.Models
{
    public class Editora
    {
        [Key()]
        public int IdEditora { get; set; }
        [Required]
        public string Nomefantasia {get; set; }
        public string Endereco {get; set; }
    }
}
