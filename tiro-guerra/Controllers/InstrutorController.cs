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
    public class Instrutor:Controller
    {
    
        public ActionResult Cadastrar()
        {
            return View("Cadastro");
        }
    }
}