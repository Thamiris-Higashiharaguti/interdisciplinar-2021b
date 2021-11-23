using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Linq;
using TiroGuerra.Repositories;
using TiroGuerra.Controllers;


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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Atirador model)
        {
           // Console.WriteLine(model.CPF, model.Senha);
            Console.WriteLine(model.Usuario.CPF);
            Console.WriteLine(model.Usuario.Senha);
            Atirador atirador = repository.Read(model.Usuario.CPF, model.Usuario.Senha);
            if(atirador == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return View();
            }

            HttpContext.Session.SetInt32("Id", (int)atirador.Usuario.Id);   
            HttpContext.Session.SetString("Nome", atirador.Usuario.Nome); 
            HttpContext.Session.SetString("CPF", atirador.Usuario.CPF); 
            HttpContext.Session.SetString("RG", atirador.Usuario.RG); 
            HttpContext.Session.SetString("Formacao", atirador.Formacao); 
            HttpContext.Session.SetString("RA", atirador.RA); 
            HttpContext.Session.SetString("Numero", atirador.Numero); 
            HttpContext.Session.SetString("Pelotao", atirador.Pelotao.Nome);
             
            ViewBag.atirador = atirador;

            return RedirectToAction("Index", "Home");

        } 


        
    }
}