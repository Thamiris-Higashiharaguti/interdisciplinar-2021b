using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;

namespace TiroGuerra.Repositories
{
    public class GuarnicaoRepository: BDContext, IGuarnicaoRepository
    {
        public Guarnicao Create(List<Guarda> model)
        {
            try
            {

                //percorre os models
                for(int i = 0; i < model.Count;i++)
                {

                     Console.WriteLine(model[i].IdAtirador);
                     Console.WriteLine(model[i].Funcao);
                }

                //split a cada cria uma lista com os 7 dias da semana

                //cria uma guarnição para cadas lista

                //cadastra cada lista de guarda para uma guarnicao

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
                
                Guarnicao gua = new Guarnicao();

                return gua;


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);

                 Guarnicao gua = new Guarnicao();

                return gua;
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