using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;

namespace TiroGuerra.Repositories
{
    public class UsuarioRepository : BDContext, IUsuarioRepository
    {
        public Atirador Read(string CPF, string Senha)
        {
            try 
            {
                //Console.WriteLine(CPF);
                Atirador atirador = new Atirador();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "";

                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@Senha", Senha);
                

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read()) 
                {
                    
                    atirador.Id = reader.GetInt32(0);
                    atirador.Nome = reader.GetString(1);
                    atirador.CPF = reader.GetString(2);
                    atirador.RG = reader.GetString(3);
                    atirador.Formacao = reader.GetString(4);
                    atirador.RA = reader.GetString(5);
                    atirador.Numero = reader.GetString(6);
                    

                    atirador.Pelotao = new Pelotao {
                        Nome = reader.GetString(7)
                    };

                    return atirador;
                }

                return null;
                
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Usuário não encontrada.");
            }
            finally {
                Dispose();
            }
        }             
    }
}

