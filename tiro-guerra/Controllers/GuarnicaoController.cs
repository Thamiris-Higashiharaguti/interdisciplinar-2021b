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

            for(int i =0; i<Guardas.Count; i++)
            {
                Console.WriteLine(Guardas[i].IdAtirador);
            }


            guardaRepository.Create(Guardas,Guarnicoes);

             return RedirectToAction("Index", "Home");
        }
    }
}