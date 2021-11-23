using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;

namespace TiroGuerra.Repositories
{
    public class InstrutorRepository: BDContext, IInstrutorRepository
    {
        public void Create(Instrutor model)
        {
            try
            {
                SqlCommand cmd= new SqlCommand();
                cmd.Connection = connection;
                
                cmd.CommandText = "CREATE_INSTRUTOR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NOME", model.Usuario.Nome);
                cmd.Parameters.AddWithValue("@STATUS",model.Usuario.Status);
                cmd.Parameters.AddWithValue("@CPF",model.Usuario.CPF);
                cmd.Parameters.AddWithValue("@RG",model.Usuario.RG);
                cmd.Parameters.AddWithValue("@GRADUACAO",model.Graduacao);
                cmd.Parameters.AddWithValue("@SENHA",model.Senha);
                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public Instrutor Read(int id)
        {

            return null;
        }
        public void Update(int id, Instrutor model)
        {
            

        }

        public void Delete(int id)
        {

        }

        public List<Instrutor> ReadAll()
        {
            try {
                List<Instrutor> lista = new List<Instrutor>();
               

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT U.id, U.Nome, U.CPF, U.RG, U.Status, I.Graduacao "+
                                "from TB_Usuario U "+
                                "INNER Join TB_Instrutor I  ON I.Id_Usuario = U.Id";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Instrutor instrutor = new Instrutor();
                    instrutor.Usuario.Id = reader.GetInt32(0);
                    instrutor.Usuario.Nome = reader.GetString(1);
                    instrutor.Usuario.CPF = reader.GetString(2);
                    instrutor.Usuario.RG = reader.GetString(3);
                    instrutor.Usuario.Status = reader.GetBoolean(4);
                    instrutor.Graduacao = reader.GetString(5);

                    lista.Add(instrutor);
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