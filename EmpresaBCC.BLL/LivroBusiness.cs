using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpresaBCC.Entities;
using EmpresaBCC.DAL;

namespace EmpresaBCC.BLL
{
    public class LivroBusiness
    {
        private LivroRepository repository;

        public LivroBusiness()
        {
            repository = new LivroRepository();
        }

        
        public void Cadastrar(Livro livro)
        {

            if (repository.HasIsbn(livro.Isbn) == " ")
            {
                repository.Insert(livro);
            }
            else
            {
                throw new Exception($"Isbn {livro.Isbn} já cadastrado no sistema.");
            }

        }

        public void Atualizar(Livro livro)
        {
            repository.Update(livro);
        }

        public void Excluir(int id)
        {
            repository.Delete(id);
        }

        public List<Livro> ConsultarLivro()
        {
            return repository.SelectAll();
        }

        public Livro ConsultarLivroPorId(int id)
        {
            return repository.SelectById(id);
        }
    }
}
