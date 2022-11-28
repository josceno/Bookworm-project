using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookworm.Models
{
    public class Livro
    {
        [Key()]
        public int id_livro { get; set; }
        public int qtd_paginas { get; set; }   
        public string Sinopse { get; set;}
       // public double preco { get; set; }
        public string NomeLivro { get; set; }
        [ForeignKey("Editora")]
        public int idEditora { get; set; }
        public virtual Editora Editora { get; set; }

        
    
    }
}
