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

                cmd.CommandText = "SELECT U.id, U.Nome, U.CPF, U.RG, A.Formacao, A.RA, " 
                +"A.Numero, P.Nome Pelotao "
                +"FROM TB_Atirador A "
                +"INNER JOIN TB_Usuario  U ON (A.Id_Usuario = U.Id) "
                +"INNER JOIN TB_Pelotao P ON (A.Id_Pelotao = P.Id) "
                +"Where U.CPF = @CPF AND U.Senha = @Senha";

                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@Senha", Senha);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    
                    usuario.Id = reader.GetInt32(0);
                    usuario.Nome = reader.GetString(1);
                    usuario.CPF = reader.GetString(2);
                    usuario.RG = reader.GetString(3);
                    
                    Console.WriteLine(usuario);
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

