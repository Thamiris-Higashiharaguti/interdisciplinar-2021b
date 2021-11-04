using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;

namespace TiroGuerra.Repositories
{
    public class PelotaoRepository : BDContext, IPelotaoRepository
    {
        public void Create(Pelotao model)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

               

                cmd.CommandText = "CREATE_ATIRADOR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", model.Id);
                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@Ano", model.Ano);


                cmd.ExecuteNonQuery();

            }catch(Exception ex) {
                // Armazenar a exceção em um log.
                Console.WriteLine(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public List<Pelotao> ReadAll()
        {
            try {
                List<Pelotao> lista = new List<Pelotao>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM TB_Pelotao";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Pelotao pelotao = new Pelotao();
                    pelotao.Id = reader.GetInt32(0);
                    pelotao.Nome = reader.GetString(1);
                    pelotao.Ano = reader.GetDateTime(2);


                    lista.Add(pelotao);
                }

                return lista;
            }catch(Exception ex) {
                // Armazenar a exceção em um log.
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        
    }
}