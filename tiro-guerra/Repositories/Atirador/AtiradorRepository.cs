using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;

namespace TiroGuerra.Repositories
{
    public class AtiradorRepository : BDContext, IAtiradorRepository
    {
        public void Create(Atirador model)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                
                cmd.CommandText = "CREATE_ATIRADOR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@CPF", model.CPF);
                cmd.Parameters.AddWithValue("@RG", model.RG);
                cmd.Parameters.AddWithValue("@Status", model.Status);
                cmd.Parameters.AddWithValue("@Senha", model.Senha);
                cmd.Parameters.AddWithValue("@Id_Pelotao", model.IdPelotao);
                cmd.Parameters.AddWithValue("@Formacao", model.Formacao);
                cmd.Parameters.AddWithValue("@RA", model.RA);
                cmd.Parameters.AddWithValue("@Numero", model.Numero);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                

                cmd.ExecuteNonQuery();

            }catch(Exception ex) {
                // Armazenar a exceção em um log.
                Console.WriteLine(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public void Delete(int id)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "DELETE_ATIRADOR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }catch(Exception ex) 
            {
                  Console.WriteLine(ex.Message);    
            }
            finally {
                Dispose();
            }
        }

        public void Update(int id, Atirador model)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE_ATIRADOR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@CPF", model.CPF);
                cmd.Parameters.AddWithValue("@RG", model.RG);
                cmd.Parameters.AddWithValue("@Status", model.Status);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Id_Pelotao", model.IdPelotao);
                cmd.Parameters.AddWithValue("@Formacao", model.Formacao);
                cmd.Parameters.AddWithValue("@RA", model.RA);
                cmd.Parameters.AddWithValue("@Numero", model.Numero);
                cmd.Parameters.AddWithValue("@id", id); 

                cmd.ExecuteNonQuery();
            }catch(Exception ex) 
            {
                  Console.WriteLine(ex.Message);
                // Armazenar a exceção em um log.
            }
            finally {
                Dispose();
            }
        }

        public List<Atirador> ReadAll()
        {
            try {
                List<Atirador> lista = new List<Atirador>();
               

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT U.id, U.Nome, U.CPF, U.RG, U.Status,U.Email,A.Formacao, A.RA, A.Numero, P.Nome "+
                "from TB_Atirador A "+
                "INNER Join TB_Usuario U ON A.Id_Usuario = U.Id "+
                "Inner Join TB_Pelotao P ON A.Id_Pelotao = P.id where U.Status = 1";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Atirador atirador = new Atirador();
                    atirador.Id = reader.GetInt32(0);
                    atirador.Nome = reader.GetString(1);
                    atirador.CPF = reader.GetString(2);
                    atirador.RG = reader.GetString(3);
                    atirador.Status = reader.GetBoolean(4);
                    atirador.Email = reader.GetString(5);
                    atirador.Formacao = reader.GetString(6);
                    atirador.RA = reader.GetString(7);
                    atirador.Numero = reader.GetString(8);
            
                    
                    atirador.Pelotao = new Pelotao {
                        Nome = reader.GetString(9)
                    };

                    lista.Add(atirador);
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

        

        public Atirador Read(int id)
        {
            try 
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SEARCH_ATIRADOR";
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if(reader.Read()) 
                {
                    Atirador atirador = new Atirador();
                    atirador.Id = reader.GetInt32(0);
                    atirador.Nome = reader.GetString(1);
                    atirador.CPF = reader.GetString(2);
                    atirador.RG = reader.GetString(3);
                    atirador.Email = reader.GetString(4);
                    atirador.Formacao = reader.GetString(5);
                    atirador.RA = reader.GetString(6);
                    atirador.Numero = reader.GetString(7);
                    


                    atirador.Pelotao = new Pelotao {
                        Nome = reader.GetString(8)
                    };

                    return atirador;
                }

                return null;
                
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

        public Atirador Read(string CPF, string Senha)
        {
            try 
            {
                Atirador atirador = new Atirador();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT U.id, U.Nome, U.CPF, U.RG,A.Formacao, A.RA, A.Numero, P.Nome "
                +"FROM TB_Atirador A "
                +"INNER JOIN TB_Usuario  U ON (A.Id_Usuario = U.Id) "
                +"INNER JOIN TB_Pelotao P ON (A.Id_Pelotao = P.Id) "
                +"Where U.CPF = @CPF AND U.Senha = @Senha";

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
                throw new Exception("Atirador não encontrada.");
            }
            finally {
                Dispose();
            }
        } 
                       
    }
}

