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

                   // Console.WriteLine(idfiscal[i]);
                    //Console.WriteLine(dias[i]);

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

        
        public List<Guarnicao> Read(DateTime domingo, DateTime sabado)
        {

            List<Guarnicao> Guarnicoes = new List<Guarnicao>();
            SqlDataReader reader;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SEARCH_GUARNICOES";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@domingo", domingo);
            cmd.Parameters.AddWithValue("@sabado", sabado);

            reader = cmd.ExecuteReader();

            while(reader.Read()){

                Instrutor instrutor = new Instrutor();
                instrutor.Nome =reader.GetString(3);
                instrutor.Graduacao = reader.GetString(4);


                Guarnicoes.Add(new Guarnicao{
                    Id =reader.GetInt32(0),
                    Id_Instrutor = reader.GetInt32(2),
                    Data =  reader.GetDateTime(1),
                    Instrutor = instrutor
                    });
            }

            return Guarnicoes;
        }
        public void Update(int id, Guarnicao model)
        {
            

        }

        public void Delete(int id)
        {

        }
    }
}