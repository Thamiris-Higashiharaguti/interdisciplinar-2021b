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
                   
        public List<Chamada> ReadByPelotao(int Id_Pelotao)
        {
            try 
            {
                List<Chamada> lista = new List<Chamada>();
                Chamada chamada = new Chamada();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                

                cmd.CommandText = "SELECT U.id, U.Nome, U.CPF, U.RG, U.Status,U.Email,A.Formacao, A.RA, A.Numero, P.Nome, C.Presenca from TB_Atirador A INNER Join TB_Usuario U ON A.Id_Usuario = U.Id Inner Join TB_Pelotao P ON A.Id_Pelotao = P.id Inner Join TB_Chamada C ON U.Id = C.Id_Atirador Inner Join TB_Instrucao I ON C.Id_Instrucao = I.Id where A.Id_Pelotao = @Id_Pelotao";

                //cmd.Parameters.AddWithValue("@Data", data.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Id_Pelotao", Id_Pelotao);
                
                
                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    chamada.IdAtirador = reader.GetInt32(0);
                    chamada.Responsavel.Nome = reader.GetString(1);
                    chamada.Responsavel.CPF = reader.GetString(2);
                    chamada.Atirador.RG = reader.GetString(3);
                    chamada.Atirador.Status = reader.GetBoolean(4);
                    chamada.Atirador.Email = reader.GetString(5);
                    chamada.Atirador.Formacao = reader.GetString(6);
                    chamada.Atirador.RA = reader.GetString(7);
                    chamada.Atirador.Numero = reader.GetString(8);
                    chamada.Atirador.Pelotao = new Pelotao {
                        Nome = reader.GetString(9)
                    };
                    chamada.Presenca = reader.GetBoolean(10);
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
        
    }
}