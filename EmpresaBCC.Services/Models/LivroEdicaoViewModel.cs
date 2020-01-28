using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmpresaBCC.Services.Models
{
    public class LivroEdicaoViewModel
    {
        public int IdLivro { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public long Isbn { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string NomeLivro { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public DateTime DataPublicacao { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string ImagemCapa { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string NomeAutor { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public int IdAutor { get; set; }
    }
}