using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TiroGuerra.Controllers
{
    public class Atirador:Controller
    {
        public ActionResult login()
        {
            return View();
        }

        public ActionResult cadastrarAtirador()
        {
            return View("CadastroAtirador");
        }

        public ActionResult cadastrarInstrutor()
        {
            return View("CadastroInstrutor");
        }
    }
}