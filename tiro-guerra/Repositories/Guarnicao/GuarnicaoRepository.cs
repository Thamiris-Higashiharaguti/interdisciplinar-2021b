using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Text;
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

            finally
            {
                Dispose();
            }

        }


        public List<Guarnicao> Read(DateTime domingo, DateTime sabado)
        {
            try{
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
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                List<Guarnicao> Guarnicoes = new List<Guarnicao>();
                return Guarnicoes;


            }
            finally{
                Dispose();
            }

        }
        public void Update(List<Guarnicao> model)
        {
            try{

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                for(int i = 0; i < model.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE_GUARNICAO";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", model[i].Id);
                    cmd.Parameters.AddWithValue("@Id_Instrutor", model[i].Id_Instrutor);
                    cmd.ExecuteNonQuery();
                }

            }
            catch(Exception ex){
                Console.WriteLine(ex);
            }
            finally
            {
                Dispose();
            }


        }

        public void Delete(int id)
        {
        }

        public void Email(string emailDestinatario, String mensagem, String Nome){

            try
            {
                MailMessage mailMessage = new MailMessage("adm.tg02033sjrp@gmail.com", emailDestinatario);

                mailMessage.Subject = "Alteração na escala: "+ Nome;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "<p> "+ mensagem +" </p>";
                mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("adm.tg02033sjrp@gmail.com", "tg@123456");

                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

                Console.WriteLine("Seu email foi enviado com sucesso! :)");
                Console.ReadLine();
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("Houve um erro no envio do email :(");
                Console.ReadLine();
                return;
            }
            finally {
                Dispose();
            }
        }  
    }
}