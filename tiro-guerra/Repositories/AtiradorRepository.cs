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

                cmd.CommandText = "DELETE FROM TB_Atirador WHERE Id = @id";

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

                cmd.CommandText = "UPDATE_ATIRADOR";

                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@CPF", model.CPF);
                cmd.Parameters.AddWithValue("@RG", model.RG);
                cmd.Parameters.AddWithValue("@Status", model.Status);
                cmd.Parameters.AddWithValue("@Senha", model.Senha);
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

                cmd.CommandText = "SELECT U.id, U.Nome, U.CPF, U.RG, U.Status,A.Formacao, A.RA, A.Numero, A.GDA_Preta, A.GDA_Vermelha, P.Nome from TB_Atirador AS A INNER Join TB_Usuario AS U ON A.Id_Usuario = U.Id Inner Join TB_Pelotao AS P ON A.Id_Pelotao = P.Id";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Atirador atirador = new Atirador();
                    atirador.Id = reader.GetInt32(0);
                    atirador.Nome = reader.GetString(1);
                    atirador.CPF = reader.GetString(2);
                    atirador.RG = reader.GetString(3);
                    atirador.Status = reader.GetBoolean(4);
                    atirador.Formacao = reader.GetString(5);
                    atirador.RA = reader.GetString(6);
                    atirador.Numero = reader.GetString(7);
                    
                    atirador.Pelotao = new Pelotao {
                        Nome = reader.GetString(10)
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

                cmd.CommandText = "SELECT U.id, U.Nome, U.CPF, U.RG, U.Status,A.Formacao, A.RA, A.Numero, A.GDA_Preta, A.GDA_Vermelha, P.Nome from TB_Atirador AS A INNER Join TB_Usuario AS U ON A.Id_Usuario = U.Id Inner Join TB_Pelotao AS P ON A.Id_Pelotao = P.Id WHERE U.Id = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if(reader.Read()) 
                {
                    Atirador atirador = new Atirador();
                    atirador.Id = reader.GetInt32(0);
                    atirador.Nome = reader.GetString(1);
                    atirador.CPF = reader.GetString(2);
                    atirador.RG = reader.GetString(3);
                    atirador.Status = reader.GetBoolean(4);
                    atirador.Formacao = reader.GetString(5);
                    atirador.RA = reader.GetString(6);
                    atirador.Numero = reader.GetString(7);
                    atirador.GDAPreta = reader.GetDateTime(8);
                    atirador.GDAVermelha = reader.GetDateTime(9);
                    


                    atirador.Pelotao = new Pelotao {
                        Nome = reader.GetString(10)
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