using System.ComponentModel.DataAnnotations;

namespace Bookworm.Models
{
    public class Cliente
    {
        [Key]
        public string cpf { get; set; }
        public string NomeCliente { get; set; }
        public string genero { get; set; }
        public int idade { get; set; }
        public string edereco { get; set; }
    }
}
