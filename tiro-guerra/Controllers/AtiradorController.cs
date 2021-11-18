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
    public class AtiradorController:Controller
    {
        private IAtiradorRepository repository;
        private IPelotaoRepository Pelotaorepository;

        public AtiradorController(IAtiradorRepository repository, IPelotaoRepository Pelotaorepository) 
        {
            this.repository = repository;
            this.Pelotaorepository = Pelotaorepository;
        }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Atirador model)
        {
            
            Atirador atirador = repository.Read(model.CPF, model.Senha);
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


        [HttpGet]
        public ActionResult Create()
        {   
            ViewBag.pelotoes = Pelotaorepository.ReadAll();
            return View();
        }

         [HttpPost]
        public ActionResult Create(Atirador model)
        {
            repository.Create(model);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult Conta()
        {   
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {   
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}