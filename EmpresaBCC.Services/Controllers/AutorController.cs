using System;
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
    [RoutePrefix("api/Autor")]
    public class AutorController : ApiController
    {
        private AutorBusiness business;

        public AutorController()
        {
            business = new AutorBusiness();
        }

        [HttpPost]
        public HttpResponseMessage Post(AutorCadastroViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Autor autor = new Autor
                    {
                        NomeAutor = model.Nome
                    };

                    business.Cadastrar(autor);

                    return Request.CreateResponse(HttpStatusCode.OK, "Autor cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro: " + ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreram erros de validação.");
            }
        }


        [HttpPut]
        public HttpResponseMessage Put(AutorEdicaoViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Autor autor = new Autor
                    {
                        IdAutor = model.IdAutor,
                        NomeAutor = model.Nome
                    };

                    business.Atualizar(autor);

                    return Request.CreateResponse(HttpStatusCode.OK, "Autor atualizado com sucesso!");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro: " + ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreram erros de validação.");
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

                    return Request.CreateResponse(HttpStatusCode.OK, "Autor excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro: " + ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreram erros de validação.");
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {

            List<AutorConsultaViewModel> lista = new List<AutorConsultaViewModel>();

            try
            {

                foreach (Autor autor in business.ConsultarAutor())
                {
                    AutorConsultaViewModel model = new AutorConsultaViewModel()
                    {
                        IdAutor = autor.IdAutor,
                        Nome = autor.NomeAutor
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
                Autor autor = business.ConsultarAutorPorId(id);

                AutorConsultaViewModel model = new AutorConsultaViewModel
                {
                    IdAutor = autor.IdAutor,
                    Nome = autor.NomeAutor
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
