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
    public class AutorRepository
    {

        private  string connectionString;

        ConexaoOracle strConexao = new ConexaoOracle();


        public AutorRepository()
        {
            connectionString = strConexao.conectarOracle();
        }

        public void Insert(Autor autor)
        {

            using (var conn = new OracleConnection(connectionString))
            {
                var query = "INSERT INTO Autor (IdAutor, NomeAutor) VALUES (TB_LIVRO_SEQ.NEXTVAL, :NomeAutor)";

                conn.Execute(query, autor);
            }
        }

        public void Update(Autor autor)
        {
            using (var conn = new OracleConnection(connectionString))
            {
                var query = "UPDATE Autor SET NomeAutor =  :NomeAutor WHERE IdAutor = :IdAutor";

                conn.Execute(query, autor);
            }
        }

        public void Delete(int id)
        {
            using (var conn = new OracleConnection(connectionString))
            {
                var query = "DELETE FROM Autor WHERE IdAutor = :IdAutor";

                conn.Execute(query, new { IdAutor = id });
            }
        }

        public List<Autor> SelectAll()
        {
            using (var conn = new OracleConnection(connectionString))
            {
                var query = "SELECT * FROM Autor ";

                return conn.Query<Autor>(query).ToList();
            }
        }

        public Autor SelectById(int id)
        {
            using (var conn = new OracleConnection(connectionString))
            {
                var query = "SELECT * FROM Autor WHERE IdAutor = :IdAutor";

                return conn.QuerySingleOrDefault<Autor>(query, new { IdAutor = id });
            }
        }
    }
}
