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
            List<Chamada> lista = new List<Chamada>();
            var atiradores = repository.ReadAll();
            foreach(var i in atiradores){
                lista.Add(new Chamada{
                    IdAtirador = i.Usuario.Id,
                    Atirador = i,
                    Presenca = false
                    

                });
            }
            return View(lista);
        }

        [HttpPost]
        public ActionResult create([Bind("IdAtirador, Presenca")]List<Chamada> model)
        {
            if (ModelState.IsValid)
            {
                model.Count();
            }

            var id = HttpContext.Session.GetInt32("Id");
            
            
                
            chamadaRepository.Create(model, (int)id);
            
            
            return RedirectToAction("Index", "Home");
        }
    }
}