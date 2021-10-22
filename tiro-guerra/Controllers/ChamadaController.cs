using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TiroGuerra.Controllers
{
    public class Chamada:Controller
    {
        public ActionResult chamada()
        {
            return View();
        }
    }
}