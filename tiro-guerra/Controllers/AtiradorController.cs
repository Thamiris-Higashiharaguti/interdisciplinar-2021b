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
            List<Models.Atirador> atiradores = repository.ReadAll();
            

            return View();
        }

        public ActionResult cadastrarAtirador()
        {
            return View("CadastroAtirador");
        }

        public ActionResult cadastrarInstrutor()
        {
            return View("CadastroInstrutor");
        }
    }
}