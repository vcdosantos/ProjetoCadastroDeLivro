using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaBCC.Entities
{
    public class Autor
    {
        public int IdAutor { get; set; }
        public string NomeAutor { get; set; }

        public List<Livro> Livros { get; set; }

        public Autor()
        {

        }

        public Autor(int idAutor, string nome, List<Livro> livros)
        {
            IdAutor = idAutor;
            NomeAutor = nome;
            Livros = livros;
        }

        public override string ToString()
        {
            return $"Id: {IdAutor}, Nome: {NomeAutor},  Livros: {Livros}";
        }

    }
}
