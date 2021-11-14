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

        public ChamadaController(IAtiradorRepository repository) 
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult index()
        {
            List<Atirador> atiradores = repository.ReadAll();
            return View(atiradores);
        }
    }
}