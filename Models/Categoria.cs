namespace Bookworm.Models
{
    public class Categoria
    {   
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public DateTime Datacriacao { get; set; } = DateTime.Now;



    }
}
