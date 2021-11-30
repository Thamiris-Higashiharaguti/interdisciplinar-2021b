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
            
            /*CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            
            int dia = DateTime.Now.Day;
            int ano = DateTime.Now.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
            string diasemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(DateTime.Now.DayOfWeek));
            string data = diasemana + ", " + dia + " de " + mes + " de " + ano;*/

            ViewBag.instrutor = repository.Read(id);
            return View("Update");
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