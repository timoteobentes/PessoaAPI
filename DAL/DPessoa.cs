using Npgsql;
using System.Collections.Generic;
using System;
using PessoaAPI.Models;

namespace PessoaAPI.DAL
{
    public class DAOPessoa{
        public List<Pessoa> RetornarPessoas(){
            var connString = "Host=localhost;Username=postgres;Password=Timoteo12;Database=DotNetCoreAPIPessoas";

            List<Pessoa> lstPessoa = new List<Pessoa>();

            try{
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT Id, CPF, Nome FROM \"Pessoa\"", conn))
                    using (var reader = cmd.ExecuteReader())
                    while (reader.Read()){
                        Pessoa pessoa = new Pessoa();
                        pessoa.Id = (Int64)reader["Id"];
                        pessoa.CPF = (Int64)reader["CPF"];
                        pessoa.Nome = reader.GetString(2);
                        lstPessoa.Add(pessoa);
                    }
                    conn.Close();
                }
            }catch(Exception ex){
                string teste = ex.Message;
            }

            return lstPessoa;
        }
    }
}