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


        public ActionResult index()
        {
            return View();
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
        public ActionResult Search()
        {
            ViewBag.atiradores = repository.ReadAll();
            return View();
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

        [HttpGet]
        public ActionResult Fatd(int id)
        {
            ViewBag.atirador = repository.Read(id);
            return View("Fatd");
        }
    }
}