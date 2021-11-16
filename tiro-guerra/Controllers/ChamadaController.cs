using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using TiroGuerra.Repositories;
using TiroGuerra.Controllers;
using System.Linq;

namespace TiroGuerra.Controllers
{
    public class ChamadaController:Controller
    {
        //private IChamadaRepository repository;
        private IAtiradorRepository repository;
        private IChamadaRepository chamadaRepository;

        public ChamadaController(IAtiradorRepository repository,  IChamadaRepository chamadaRepository) 
        {
            this.repository = repository;
            this.chamadaRepository = chamadaRepository;
        }

        [HttpGet]
        public ActionResult index()
        {
            ViewBag.atiradores = repository.ReadAll();
            return View();
        }

        [HttpPost]
        public ActionResult create(List<Chamada> model)
        {
            var id = HttpContext.Session.GetInt32("id");
            Console.WriteLine(model.Count);
            foreach(var chamada in model){
                
                chamadaRepository.Create(chamada,(int)id);
            
            }
            return RedirectToAction("Index", "Home");
        }
    }
}