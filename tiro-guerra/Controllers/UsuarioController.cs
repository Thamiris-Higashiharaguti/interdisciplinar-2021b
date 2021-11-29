using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Linq;
using TiroGuerra.Repositories;
using TiroGuerra.Controllers;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace TiroGuerra.Controllers
{
    public class UsuarioController:Controller
    {
        private IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository) 
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario model)
        {
            Usuario usuario = repository.Read(model.CPF, model.Senha);
            if(usuario == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return View();
            }

            HttpContext.Session.SetInt32("Id", (int)usuario.Id);   
            HttpContext.Session.SetString("Nome", usuario.Nome); 
            HttpContext.Session.SetString("CPF", usuario.CPF); 
            HttpContext.Session.SetString("RG", usuario.RG); 
            ViewBag.usuario = usuario;

            return RedirectToAction("Index", "Home");

        }

        public void EmailAtirador(string emailDestinatario){

            try
            {
                MailMessage mailMessage = new MailMessage("adm.tg02033sjrp@gmail.com", emailDestinatario);

                mailMessage.Subject = "Justificativa de Falta"; //Título
                mailMessage.IsBodyHtml = true; //Define que é HTML
                mailMessage.Body = "<p> Foi registrada uma falta para você. </p>"; //Corpo da Mensagem
                mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("adm.tg02033sjrp@gmail.com", "tg@123456");

                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

                Console.WriteLine("Seu email foi enviado com sucesso");
            }
            catch (Exception)
            {
                Console.WriteLine("Houve um erro no envio do email");
            }
        }
    }
}