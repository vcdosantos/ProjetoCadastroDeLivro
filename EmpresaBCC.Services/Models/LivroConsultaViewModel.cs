using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmpresaBCC.Services.Models
{
    public class LivroConsultaViewModel
    {
        public int IdLivro { get; set; }
        public long Isbn { get; set; }

        [Display(Name = "Nome do Livro")]
        public string NomeLivro { get; set; }

        public decimal Preco { get; set; }

        [DisplayFormat(DataFormatString = "mm/dd/yy")]
        public DateTime DataPublicacao { get; set; }
        public string ImagemCapa { get; set; }

        [Display(Name = "Nome do Autor")]
        public string NomeAutor { get; set; }

        public int IdAutor { get; set; }

    }
}