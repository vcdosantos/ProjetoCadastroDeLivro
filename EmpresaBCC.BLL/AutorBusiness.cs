using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpresaBCC.Entities;
using EmpresaBCC.DAL;

namespace EmpresaBCC.BLL
{
    public class AutorBusiness
    {
        private AutorRepository repository;

        public AutorBusiness()
        {
            repository = new AutorRepository();
        }

        public void Cadastrar(Autor autor)
        {
            repository.Insert(autor);
        }

        public void Atualizar(Autor autor)
        {
            repository.Update(autor);
        }

        public void Excluir(int id)
        {
            repository.Delete(id);
        }

        public List<Autor> ConsultarAutor()
        {
            return repository.SelectAll();
        }

        public Autor ConsultarAutorPorId(int id)
        {
            return repository.SelectById(id);
        }
    }
}
