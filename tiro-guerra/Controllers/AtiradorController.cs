using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Linq;
using TiroGuerra.Repositories;
using TiroGuerra.Controllers;


namespace TiroGuerra.Controllers
{
    public class AtiradorController:Controller
    {
        private IAtiradorRepository repository;
        private IPelotaoRepository Pelotaorepository;

        public AtiradorController(IAtiradorRepository repository, IPelotaoRepository Pelotaorepository) 
        {
            this.repository = repository;
            this.Pelotaorepository = Pelotaorepository;
        }


        public ActionResult index()
        {
            return View();
        }

        


        [HttpGet]
        public ActionResult Create()
        {   
            ViewBag.pelotoes = Pelotaorepository.ReadAll();
            return View();
        }

         [HttpPost]
        public ActionResult Create(Atirador model)
        {
            repository.Create(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Search()
        {
            ViewBag.atiradores = repository.ReadAll();
            return View();
        }
        
        [HttpGet]
        public ActionResult Conta()
        {   
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {   
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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
            
            
            ViewBag.atirador = repository.Read(id);
            ViewBag.pelotoes = Pelotaorepository.ReadAll();
            return View("Update");
        }

        [HttpPost]
        public ActionResult Update(Atirador model)
        {
            
            /*CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            
            int dia = DateTime.Now.Day;
            int ano = DateTime.Now.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
            string diasemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(DateTime.Now.DayOfWeek));
            string data = diasemana + ", " + dia + " de " + mes + " de " + ano;*/
        
            
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