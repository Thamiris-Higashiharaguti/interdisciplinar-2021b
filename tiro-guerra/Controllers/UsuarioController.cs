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

                repository.Email(emailDestinatario);
                //teste aqui

            }
            catch (Exception)
            {
                Console.WriteLine("Houve um erro no envio do email");
            }
        }
    }
}
