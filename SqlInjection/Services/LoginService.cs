using Microsoft.Extensions.Configuration;
using SqlInjection.Interface;
using SqlInjection.Models;
using System.Data.SqlClient;
using Dapper;
using System;

namespace SqlInjection.Services
{
    public class LoginService : ILoginService
    {
        public Usuario LoginComPrepared(IConfiguration config, Usuario usuario)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(config.GetConnectionString("SqlInjectionBD")))
                {

                    con.Open();
                    var command = $"select top 1 * from usuario where Nome = @NomeParam and Senha = @SenhaParam";
                    var response = con.QueryFirst<Usuario>(command, new { NomeParam = usuario.Nome, SenhaParam = usuario.Senha });
                    return usuario;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Usuario LoginSemPrepared(IConfiguration config, Usuario usuario)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(config.GetConnectionString("SqlInjectionBD")))
                {

                    con.Open();
                    var command = $"select top 1 * from usuario where Nome = '{usuario.Nome}' and Senha = '{usuario.Senha}'";
                    var response = con.QueryFirst<Usuario>(command);
                    return usuario;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
