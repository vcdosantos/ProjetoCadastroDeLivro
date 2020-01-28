using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpresaBCC.BLL;
using EmpresaBCC.Entities;
using EmpresaBCC.Services.Models;

namespace EmpresaBCC.Services.Controllers
{
    [RoutePrefix("api/Livro")]
    public class LivroController : ApiController
    {
        private LivroBusiness  business;

        public LivroController()
        {
            business = new LivroBusiness();
        }

        [HttpPost]
        public HttpResponseMessage Post(LivroCadastroViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    Livro livro = new Livro
                    {
                        Isbn = model.Isbn,
                        NomeLivro = model.Nome,
                        Preco = model.Preco,
                        DataPublicacao = model.DataPublicacao,
                        ImagemCapa = model.ImagemCapa,
                        IdAutor = model.IdAutor
                    };

                    business.Cadastrar(livro);

                    return Request.CreateResponse(HttpStatusCode.OK, "Livro cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreram erros de validações.");
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(LivroEdicaoViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Livro livro = new Livro
                    {
                        IdLivro = model.IdLivro,
                        NomeLivro = model.NomeLivro,
                        Autor = new Autor
                        {
                            NomeAutor = model.NomeLivro
                        },
                        Isbn = model.Isbn,
                        Preco = model.Preco,
                        DataPublicacao = model.DataPublicacao,
                        ImagemCapa = model.ImagemCapa,
                        IdAutor = model.IdAutor
                    };

                    business.Atualizar(livro);

                    return Request.CreateResponse(HttpStatusCode.OK, "Livro atualizado com sucesso!");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro: " + ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreram erros de validações.");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    business.Excluir(id);

                    return Request.CreateResponse(HttpStatusCode.OK, "Livro excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro: " + ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreram erros de validações.");
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {

            List<LivroConsultaViewModel> lista = new List<LivroConsultaViewModel>();

            try
            {
                
                foreach (Livro livro in business.ConsultarLivro())
                {

                    LivroConsultaViewModel model = new LivroConsultaViewModel()
                    {
                        IdLivro = livro.IdLivro,
                        Isbn = livro.Isbn,
                        NomeLivro = livro.NomeLivro,
                        NomeAutor = livro.Autor.NomeAutor,
                        Preco = livro.Preco,
                        DataPublicacao = livro.DataPublicacao,
                        ImagemCapa = livro.ImagemCapa,
                        IdAutor = livro.IdAutor

                    };

                    lista.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro: " + ex.Message);
            }

        }

        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {

            try
            {
                Livro livro = business.ConsultarLivroPorId(id);


                LivroConsultaViewModel model = new LivroConsultaViewModel()
                {
                    IdLivro = livro.IdLivro,
                    Isbn = livro.Isbn,
                    NomeLivro = livro.NomeLivro,
                    NomeAutor = livro.Autor.NomeAutor,
                    Preco = livro.Preco,
                    DataPublicacao = livro.DataPublicacao,
                    ImagemCapa = livro.ImagemCapa,
                    IdAutor = livro.IdAutor

                };

                return Request.CreateResponse(HttpStatusCode.OK, model);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro: " + ex.Message);
            }

        }
    }
}
