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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Instrutor model)
        {
            repository.Create(model);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Search()
        {
            ViewBag.instrutores = repository.ReadAll();
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            ViewBag.instrutor = repository.Read(id);
            return View("Update");
        }

        [HttpPost]
        public ActionResult filtrarNome(string nome)
        {

            ViewBag.instrutores = repository.readFiltro(nome);
            return View("Search");
        }


        [HttpPost]
        public ActionResult Update(Instrutor model)
        {
            repository.Update(model.Id,model);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int Id)
        {
            Console.WriteLine(Id);
            
            repository.Delete(Id);
            return RedirectToAction("Index", "Home");
        }
    }
}