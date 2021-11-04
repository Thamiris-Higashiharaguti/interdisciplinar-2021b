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
    public class Pelotao:Controller
    {
        private IPelotaoRepository repository;
        public Pelotao(IPelotaoRepository repository) 
        {
            this.repository = repository;
        }

        

    }
}