using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TiroGuerra.Controllers
{
    public class ChamadaController:Controller
    {
        public ActionResult index()
        {
            return View();
        }
    }
}