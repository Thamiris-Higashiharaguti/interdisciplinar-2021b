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
    public class GuarnicaoController:Controller
    {

        private IAtiradorRepository repository;
        private IGuarnicaoRepository guarnicaoRepository;

        public GuarnicaoController(IAtiradorRepository repository,  IGuarnicaoRepository chamadaRepository) 
        {
            this.repository = repository;
            this.guarnicaoRepository = chamadaRepository;
        }


        [HttpGet]
        public ActionResult index()
        {
            
            List<Atirador> lista = new List<Atirador>();

            var atiradores = repository.ReadAll();
           
            return View(atiradores);
            
        }
    }
}