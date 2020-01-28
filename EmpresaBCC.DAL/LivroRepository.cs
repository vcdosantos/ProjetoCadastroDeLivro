using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpresaBCC.Entities;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using Oracle.ManagedDataAccess.Client;


namespace EmpresaBCC.DAL
{
    public class LivroRepository
    {
        private string connectionString;

        ConexaoOracle strConexao = new ConexaoOracle();

        public LivroRepository()
        {
            connectionString = strConexao.conectarOracle();
        }

        public string HasIsbn(long isbn)
        {
            using (var conn = new OracleConnection(connectionString))
            {
                var resultado = " ";

                var query = "SELECT Isbn FROM Livro WHERE Isbn = :isbn";

                var resposta = conn.QuerySingleOrDefault<Livro>(query, new { Isbn = isbn });

                if(resposta == null)
                {
                    
                    return  resultado;
                }
                else
                {
                    return resposta.Isbn.ToString();
                }

            }
        }


        public void Insert(Livro livro)
        {
            using(var conn = new OracleConnection(connectionString))
            {

                var query = "INSERT INTO Livro (IdLivro, Isbn, NomeLivro, Preco, DataPublicacao, ImagemCapa, IdAutor)" +
                    " VALUES(TB_LIVRO_SEQ.NEXTVAL, :ISBN, :NomeLivro, :Preco, :DataPublicacao, :ImagemCapa, :IdAutor)";

                conn.Execute(query, livro);
            }
        }

        public void Update(Livro livro)
        {
            using (var conn = new OracleConnection(connectionString))
            {
                var query = "UPDATE Livro SET Isbn = :ISBN, NomeLivro =  :NomeLivro, Preco =  :Preco, DataPublicacao = :DataPublicacao," +
                    " ImagemCapa = :ImagemCapa, IdAutor = :IdAutor WHERE IdLivro = :IdLivro";

                conn.Execute(query, livro);
            }
        }

        public void Delete(int id)
        {
            using (var conn = new OracleConnection(connectionString))
            {
                var query = "DELETE FROM Livro WHERE IdLivro = :IdLivro";

                conn.Execute(query, new { IdLivro = id });
            }
        }

        public List<Livro> SelectAll()
        {
            using (var conn = new OracleConnection(connectionString))
            {

                var query = "SELECT * FROM Livro l INNER JOIN Autor a on l.IdAutor = a.IdAutor ";

                return conn.Query(query, 
                    (Livro l, Autor a) => 
                    {
                        l.Autor = a;
                        return l;
                    }, splitOn : "IdAutor")
                    .ToList();
            }
        }

        public Livro SelectById(int id)
        {
            using (var conn = new OracleConnection(connectionString))
            {
                var query = "SELECT * FROM  Livro l  INNER JOIN Autor a on l.IdAutor = a.IdAutor where IdLivro = :IdLivro";

                return conn.Query(query,
                   (Livro l, Autor a) =>
                   {
                       l.Autor = a;
                       return l;
                   }  
                   , new { IdLivro = id }, splitOn: "IdAutor")
                   .FirstOrDefault();
            }
        }
    }
}
