using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TiroGuerra.Controllers
{
    public class Cadastro : Controller
    {
        public ActionResult login()
        {
            return View();
        }

        public ActionResult Atirador()
        {
            return View();
        }

        public ActionResult Instrutor()
        {
            return View();
        }
    }
}