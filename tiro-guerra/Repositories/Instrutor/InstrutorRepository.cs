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

                cmd.Parameters.AddWithValue("@nome", model.Nome);
                cmd.Parameters.AddWithValue("@status",model.Status);
                cmd.Parameters.AddWithValue("@cpf",model.CPF);
                cmd.Parameters.AddWithValue("@rg",model.RG);
                cmd.Parameters.AddWithValue("@graduacao",model.Graduacao);
                cmd.Parameters.AddWithValue("@senha",model.Senha);
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
    }
}