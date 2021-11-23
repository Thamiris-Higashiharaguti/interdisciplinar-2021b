using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Linq;
using TiroGuerra.Repositories;
using TiroGuerra.Controllers;


namespace TiroGuerra.Controllers
{
    public class UsuarioController:Controller
    {
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            Usuario usuario = repository.Read(model.CPF, model.Senha);
            if(atirador == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return View();
            }

            HttpContext.Session.SetInt32("Id", (int)atirador.Id);   
            HttpContext.Session.SetString("Nome", atirador.Nome); 
            HttpContext.Session.SetString("CPF", atirador.CPF); 
            HttpContext.Session.SetString("RG", atirador.RG); 
            HttpContext.Session.SetString("Formacao", atirador.Formacao); 
            HttpContext.Session.SetString("RA", atirador.RA); 
            HttpContext.Session.SetString("Numero", atirador.Numero); 
            HttpContext.Session.SetString("Pelotao", atirador.Pelotao.Nome);
             
            ViewBag.atirador = atirador;

            return RedirectToAction("Index", "Home");

        } 
    }
}