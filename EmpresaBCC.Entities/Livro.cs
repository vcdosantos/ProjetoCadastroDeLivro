using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaBCC.Entities
{
    public class Livro
    {
        public int IdLivro { get; set; }

        public long Isbn { get; set; }
        public string NomeLivro { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string ImagemCapa { get; set; }
        public int IdAutor { get; set; }
        public Autor Autor { get; set; }


        public Livro()
        {

        }

        public Livro(int idLivro, long isbn, string nome, decimal preco, DateTime dataPublicacao, string imagemCapa, int idAutor, Autor autor)
        {
            IdLivro = idLivro;
            Isbn = isbn;
            NomeLivro = nome;
            Preco = preco;
            DataPublicacao = dataPublicacao;
            ImagemCapa = imagemCapa;
            IdAutor = idAutor;
            Autor = autor;
        }

        public override string ToString()
        {
            return $"Id: {IdLivro} ISBN: {Isbn}, Nome: {NomeLivro}, Preço: {Preco}, Data da Publicacao: {DataPublicacao}, Imagem da Capa: {ImagemCapa}, idAutor:{IdAutor}, Autor: {Autor}";
        }

    }
}
