using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;

namespace TiroGuerra.Repositories
{
    public class UsuarioRepository : BDContext, IUsuarioRepository
    {
        public Usuario Read(string CPF, string Senha)
        {
            try 
            {
                Usuario usuario = new Usuario();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;


                cmd.CommandText = "SELECT Id, Nome, CPF, RG, Email FROM TB_Usuario Where CPF = @CPF AND Senha = @Senha";


                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@Senha", Senha);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    
                    usuario.Id = reader.GetInt32(0);
                    usuario.Nome = reader.GetString(1);
                    usuario.CPF = reader.GetString(2);
                    usuario.RG = reader.GetString(3);

                    usuario.Email = reader.GetString(4);

                    return usuario;
                }

                return null;
                
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Erro na operação.");
            }
            finally {
                Dispose();
            }
        }             
    }
}

