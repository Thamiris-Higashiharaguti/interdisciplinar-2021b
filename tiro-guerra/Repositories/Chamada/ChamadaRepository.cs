using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;

namespace TiroGuerra.Repositories
{
    public class ChamadaRepository : BDContext, IChamadaRepository
    {
        public void Create(List<Chamada> model,int Id_Responsavel)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;


                for(int i = 0; i < model.Count;i++)
                {   
                    cmd.Parameters.Clear();
                    cmd.CommandText = "create_chamada";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_atirador", model[i].IdAtirador);
                    cmd.Parameters.AddWithValue("@Id_responsavel", Id_Responsavel);
                    cmd.Parameters.AddWithValue("@Presenca", model[i].Presenca);

                    
                    cmd.ExecuteNonQuery();
                    
                }
                

            }catch(Exception ex) {
                // Armazenar a exceção em um log.
                Console.WriteLine(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public List<Chamada> ReadAll()
        {
            try {
                List<Chamada> lista = new List<Chamada>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM TB_Chamada";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Chamada chamada = new Chamada();
                    chamada.IdInstrucao = reader.GetInt32(0);
                    chamada.IdAtirador = reader.GetInt32(1);
                    chamada.IdResponsavel = reader.GetInt32(2);
                    chamada.Presenca = reader.GetBoolean(3);


                    lista.Add(chamada);
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
                   
        public List<Chamada> ReadAll(int Id_Pelotao)
        {
            try 
            {
                List<Chamada> lista = new List<Chamada>();
                Chamada chamada = new Chamada();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                

                cmd.CommandText = "Select * from TB_Chamada AS C Inner Join TB_Instrucao I ON C.Id_Instrucao = I.Id Where CONVERT(varchar(10), I.Data, 23) = CONVERT(varchar(10), GETDATE(), 23)";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    chamada.IdAtirador = reader.GetInt32(0);
                    chamada.Presenca = reader.GetBoolean(1);
                    chamada.IdInstrucao = reader.GetInt32(2);
                    chamada.IdResponsavel = reader.GetInt32(3);
                    
                    lista.Add(chamada);
                }

                return lista;
                
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Atirador não encontrada.");
            }
            finally {
                Dispose();
            }
        } 

        public void Update(List<Chamada> model)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;


                for(int i = 0; i < model.Count;i++)
                {   
                    cmd.Parameters.Clear();
                    cmd.CommandText = "update_chamada";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Presenca", model[i].Presenca);
                    cmd.Parameters.AddWithValue("@Id", model[i].IdAtirador);
                    

                    
                    cmd.ExecuteNonQuery();
                    
                }
                

            }catch(Exception ex) {
                // Armazenar a exceção em um log.
                Console.WriteLine(ex.Message);
            }
            finally {
                Dispose();
            }
        }
        
    }
}