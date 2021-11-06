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

        public ActionResult login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Cadastrar()
        {
            
            
            ViewBag.pelotoes = Pelotaorepository.ReadAll();
            return View("Cadastro");
        }

         [HttpPost]
        public ActionResult Cadastrar(Atirador model)
        {
            repository.Create(model);
            return RedirectToAction("Index", "Home");
        }


    }
}