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
    public class Atirador:Controller
    {
        private IAtiradorRepository repository;

        public Atirador(IAtiradorRepository repository) 
        {
            this.repository = repository;
        }

        public ActionResult login()
        {
            return View();
        }

        public ActionResult cadastroAtirador()
        {
            List<Models.Atirador> atiradores = repository.ReadAllPelotoes();
            return View(atiradores);
        }

        public ActionResult cadastrarInstrutor()
        {
            return View("CadastroInstrutor");
        }
    }
}