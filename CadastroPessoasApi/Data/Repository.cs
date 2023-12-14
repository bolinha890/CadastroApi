using CadastroPessoasApi.ViewModel;
using Dapper;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace CadastroPessoasApi.Data
{
    public class Repository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=CADASTROPESSOA;Trusted_Connection=True;MultipleActiveResultSets=True";
        public IEnumerable<pesssoaViewModel> GetAll()
        {

            string query = "select top 1000 * from  pessoa";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.Query<pesssoaViewModel>(query);

            }
        }
        public pesssoaViewModel GetById(int pessoaId)
        {

            string query = "select * from pessoa where pessoaId = @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {

                return con.QueryFirstOrDefault<pesssoaViewModel>(query, new { pessoaId = pessoaId });

            }


        }
        public pesssoaViewModel GetByprimeironome(string primeironome)
        {

            string query = "select * from pessoa where  primeironome = @primeironome";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<pesssoaViewModel>(query, new { primeironome = @primeironome });
            }

        }


        public void Update(int pessoaId, string primeironome)
        {
            string QUERY = "UPDATE pessoa SET primeironome = @primeironome WHERE pessoaId = pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))


            {
                con.Execute(QUERY, new { pessoaId = pessoaId, primeironome = primeironome });


            }
        }

        public string Create(pesssoaViewModel pesssoa)
        {
            try
            {
                string query = @"
                 Insert INTO PESSOA(primeironome, nomemeio, UltimoNome, CPF)
                 Values (@primeironome, @nomemeio, @UltimoNome, @CPF)
                 ";
                using (SqlConnection con = new SqlConnection(conexao))
                {

                    con.Execute(query, new
                    {

                        primeironome = pesssoa.primeiroNome,
                        nomemeio = pesssoa.nomeMeio,
                        CPF = pesssoa.CPF,
                        UltimoNome = pesssoa.ultimoNome,



                    });
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}