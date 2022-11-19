using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace Bookworm.Models
{
    public class Autor
    {
        [Key()]
        public int Id_Autor { get; set; }
        public string nameAutor { get; set; }
        public string LocalNascimento { get; set; }
       
    }
}
