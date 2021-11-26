using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;

namespace TiroGuerra.Repositories
{
    public class GuarnicaoRepository: BDContext, IGuarnicaoRepository
    {
        public List<Guarnicao> Create(List<int> idfiscal, List<DateTime> dias)
        {
            try
            {

                SqlCommand cmd= new SqlCommand();
                cmd.Connection = connection;

                List<Guarnicao> Guarnicoes = new List<Guarnicao>();
                Guarnicao guarnicao = new Guarnicao();
                

                for(int i = 0; i <7; i++)
                {
                    SqlDataReader reader;

                    cmd.Parameters.Clear();
                    cmd.CommandText = "CREATE_GUARNICAO";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Instrutor", idfiscal[i]);
                    cmd.Parameters.AddWithValue("@data", dias[i]);
                    
                    reader = cmd.ExecuteReader();

                     while(reader.Read()) 
                    {
                        Guarnicoes.Add(new Guarnicao{
                        Id =reader.GetInt32(0),
                        Id_Instrutor = reader.GetInt32(1),
                        Data =  reader.GetDateTime(2)
                        });
                    }

                    reader.Close();
                   
                }

                return Guarnicoes;
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex);
                 List<Guarnicao> Guarnicoes = new List<Guarnicao>();
                 return Guarnicoes;
               

            }

        }

        
        public Guarnicao Read(int id)
        {

            return null;
        }
        public void Update(int id, Guarnicao model)
        {
            

        }

        public void Delete(int id)
        {

        }
    }
}