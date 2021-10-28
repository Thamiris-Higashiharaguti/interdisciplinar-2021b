using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TiroGuerra.Controllers
{
    public class Guarnicao:Controller
    {
        public ActionResult index()
        {
            return View();
        }
    }
}