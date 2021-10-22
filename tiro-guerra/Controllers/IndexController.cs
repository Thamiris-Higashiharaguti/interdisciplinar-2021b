using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TiroGuerra.Controllers
{
    public class Index:Controller
    {
        public ActionResult index()
        {
            return View();
        }
    }
}