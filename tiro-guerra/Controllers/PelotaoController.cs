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
    public class PelotaoController:Controller
    {   private IPelotaoRepository repository;
        public PelotaoController(IPelotaoRepository repository) 
        {
            this.repository = repository;
        }

         [HttpPost]
        public List<Pelotao> PesquisarPelotoes()
        {
            List<Pelotao> pelotoes = repository.ReadAll();
            return (pelotoes);
        }

    }
}