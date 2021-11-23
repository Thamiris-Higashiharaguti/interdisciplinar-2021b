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

        private IAtiradorRepository atirador_repository;
        private IInstrutorRepository instrutor_repository;
        private IGuarnicaoRepository guarnicaoRepository;


        public GuarnicaoController(IAtiradorRepository atirador_repository,  IGuarnicaoRepository guarnicaoRepository, IInstrutorRepository instrutor_repository) 
        {
            this.atirador_repository = atirador_repository;
            this.guarnicaoRepository = guarnicaoRepository;
            this.instrutor_repository = instrutor_repository;
        }


        [HttpGet]
        public ActionResult index()
        {

            var atiradores = atirador_repository.ReadAll();
            var instrutores = instrutor_repository.ReadAll();
           
            ViewModel mymodel = new ViewModel();

            mymodel.Instrutores = instrutores;
            mymodel.Atiradores = atiradores; 


            return View(mymodel);
            
        }
    }
}