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
        private IUsuarioRepository usuarioRepository;
        private IPelotaoRepository pelotaoRepository;


        public ChamadaController(IAtiradorRepository repository,  IChamadaRepository chamadaRepository, IUsuarioRepository usuarioRepository,IPelotaoRepository pelotaoRepository) 
        {
            this.repository = repository;
            this.chamadaRepository = chamadaRepository;
            this.usuarioRepository = usuarioRepository;
            this.pelotaoRepository = pelotaoRepository;
        }

        [HttpGet]
        public ActionResult index()
        {
            List<Chamada> lista = new List<Chamada>();
            ViewBag.pelotoes = pelotaoRepository.ReadAll();
            var atiradores = repository.ReadAll();
            foreach(var i in atiradores){
                lista.Add(new Chamada{
                    IdAtirador = i.Id,
                    Atirador = i,
                    Presenca = false
                    

                });
            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult update()
        {
            List<Chamada> lista = new List<Chamada>();
            
            ViewBag.pelotoes = pelotaoRepository.ReadAll();
            var atiradores = chamadaRepository.ReadAll();
            foreach(var atirador in atiradores)
            {   
                Chamada chamada = new Chamada();
                chamada.IdAtirador = atirador.IdAtirador;
                chamada.Presenca =  atirador.Presenca;
                chamada.Atirador = repository.Read(atirador.IdAtirador);
                lista.Add(chamada);
                
            }
           

            
            return View(lista);
        }

        [HttpPost]
        public ActionResult update([Bind("IdAtirador, Presenca","Email")]List<Chamada> model)
        {
            if (ModelState.IsValid)
            {
                model.Count();
            }
            
            var id = HttpContext.Session.GetInt32("Id");
                
            chamadaRepository.Update(model);
            for(int i = 0; i < model.Count;i++)
            {   
                if(model[i].Presenca == false){
                    usuarioRepository.Email(model[i].Atirador.Email);
                }
                
                
            }
            
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult create([Bind("IdAtirador, Presenca","Email")]List<Chamada> model)
        {
            if (ModelState.IsValid)
            {
                model.Count();
            }
            
            var id = HttpContext.Session.GetInt32("Id");
            
            Console.Write(model[0].IdAtirador);
                
            chamadaRepository.Create(model, (int)id);
            for(int i = 0; i < model.Count;i++)
            {   
                if(model[i].Presenca == false){
                    usuarioRepository.Email(model[i].Atirador.Email);
                }
                
                
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}