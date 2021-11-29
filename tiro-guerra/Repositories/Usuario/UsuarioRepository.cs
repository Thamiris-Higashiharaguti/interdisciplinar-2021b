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
    public class UsuarioRepository : BDContext, IUsuarioRepository
    {
        public Usuario Read(string CPF, string Senha)
        {
            try 
            {
                Usuario usuario = new Usuario();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT Id, Nome, CPF, RG, Email FROM TB_Usuario Where CPF = @CPF AND Senha = @Senha";

                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@Senha", Senha);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    
                    usuario.Id = reader.GetInt32(0);
                    usuario.Nome = reader.GetString(1);
                    usuario.CPF = reader.GetString(2);
                    usuario.RG = reader.GetString(3);
                    usuario.Email = reader.GetString(4);
                    Console.WriteLine(usuario);
                    return usuario;
                }

                return null;
                
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Erro na operação.");
            }
            finally {
                Dispose();
            }
            
        } 

        public void Email(string emailDestinatario){

            try
            {
                MailMessage mailMessage = new MailMessage("adm.tg02033sjrp@gmail.com", emailDestinatario);

                mailMessage.Subject = "Justificativa de Falta";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "<p> Foi registrada uma falta para você. </p>";
                mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("adm.tg02033sjrp@gmail.com", "tg@123456");

                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

                Console.WriteLine("Seu email foi enviado com sucesso! :)");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Houve um erro no envio do email :(");
                Console.ReadLine();
            }
        }            
    }
}

