using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;

namespace TiroGuerra.Repositories
{
    public class GuardaRepository: BDContext, IGuardaRepository
    {
        public void Create(Guarda model)
        {
            try
            {
                /*
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
                */
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public Guarda Read(int id)
        {

            return null;
        }
        public void Update(int id, Guarda model)
        {
            

        }

        public void Delete(int id)
        {

        }
    }
}