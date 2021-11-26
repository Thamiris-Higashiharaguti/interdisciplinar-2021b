using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using TiroGuerra.Repositories;
using TiroGuerra.Controllers;
using System.Linq;
using Microsoft.VisualBasic;

namespace TiroGuerra.Controllers
{
    public class GuarnicaoController:Controller
    {

        private IAtiradorRepository atirador_repository;
        private IInstrutorRepository instrutor_repository;
        private IGuarnicaoRepository guarnicaoRepository;
        private IGuardaRepository guardaRepository;


        public GuarnicaoController(IAtiradorRepository atirador_repository,  IGuarnicaoRepository guarnicaoRepository, IInstrutorRepository instrutor_repository, IGuardaRepository guarda_repository) 
        {
            this.atirador_repository = atirador_repository;
            this.guarnicaoRepository = guarnicaoRepository;
            this.instrutor_repository = instrutor_repository;
            this.guardaRepository = guarda_repository;
        }


        [HttpGet]
        public ActionResult index()
        {
            return View();
        }

        

        [HttpGet]
        public ActionResult create(DateTime dataEscolhida)
        {

            ViewBag.data = dataEscolhida.ToString("MM/dd/yyyy");

            var atiradores = atirador_repository.ReadAll();
            var instrutores = instrutor_repository.ReadAll();
           
            ViewModel mymodel = new ViewModel();

            mymodel.Instrutores = instrutores;
            mymodel.Atiradores = atiradores; 


            return View(mymodel);
            
        }

        [HttpPost]
        public ActionResult create(List<int> id,  List<string> Funcao, List<DateTime> dataDia, List<int> idfiscal)
        {   
            List<Guarda> Guardas = new List<Guarda>();

            for(int i = 0; i<id.Count(); i++)
            {
                Guardas.Add(new Guarda{
                    IdAtirador = id[i],
                    Funcao = Funcao[i]
                    }
                );
            }

            List<Guarnicao> Guarnicoes = new List<Guarnicao>();
   
            Guarnicoes=guarnicaoRepository.Create(idfiscal, dataDia);

            guardaRepository.Create(Guardas,Guarnicoes);

             return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public ActionResult escalaGuarda()
        {

            DateTime dateNow = DateTime.Today;
            DateTime sabado = new DateTime();
            DateTime domingo = new DateTime();

            while (true)
            {
                if(dateNow.DayOfWeek==DayOfWeek.Sunday)
                {
                  
                    domingo = dateNow;
                    break;
                }
                else
                {
                    dateNow = dateNow.AddDays(-1);
                }
                 
            }
            
            sabado = domingo.AddDays(6);

            List<Guarda> Guardas =  new List<Guarda>();
            Guardas = guardaRepository.Read(domingo,sabado);

            List<Guarnicao> Guarnicoes = new List<Guarnicao>();
            Guarnicoes = guarnicaoRepository.Read(domingo,sabado);


            Console.WriteLine(Guardas.Count());
            List<Atirador> Cabos = new List<Atirador>();
            List<Atirador> Comandantes = new List<Atirador>();
            List<Atirador> Sentinelas = new List<Atirador>();


            //Console.WriteLine(Guardas[0].IdAtirador)
            for(int i =0; i<Guardas.Count; i++)
            {   
               if(Guardas[i].Funcao=="Cabo")
               {
                   Cabos.Add(new Atirador{
                       Id = Guardas[i].IdAtirador,
                       Nome = Guardas[i].Atirador.Nome
                   });

               }
               
             else if(Guardas[i].Funcao=="Comandante")
               {
                   Comandantes.Add(new Atirador{
                       Id = Guardas[i].IdAtirador,
                       Nome = Guardas[i].Atirador.Nome
                   });
                   
               }
               else{
                    Sentinelas.Add(new Atirador{
                       Id = Guardas[i].IdAtirador,
                       Nome = Guardas[i].Atirador.Nome
                   });
               } 
                
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Cabos = Cabos;
            mymodel.Comandantes = Comandantes;
            mymodel.Sentinelas = Sentinelas; 
            mymodel.Guarnicoes = Guarnicoes; 

            return View(mymodel);
        }
    }
}