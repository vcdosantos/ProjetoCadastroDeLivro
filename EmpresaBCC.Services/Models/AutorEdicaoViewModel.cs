using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmpresaBCC.Services.Models
{
    public class AutorEdicaoViewModel
    {
        [Required(ErrorMessage = "campo obrigatório.")]
        public int IdAutor { get; set; }

        [Required(ErrorMessage = "campo obrigatório.")]
        public string Nome { get; set; }
    }
}