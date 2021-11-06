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
    public class InstrutorController:Controller
    {
        private IInstrutorRepository repository;

        public InstrutorController(IInstrutorRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View("Cadastro");
        }

        [HttpPost]
        public ActionResult Cadastrar(Instrutor model)
        {
            repository.Create(model);
            return RedirectToAction("Index","Home");
        }
    }
}