using Microsoft.AspNetCore.Mvc;

namespace _27112023.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Menu(string nome="testenome", int quantidade=3)
        {

            ViewData["nome"] = nome;
            ViewData["quantidade"] = quantidade;

            return View();
        }
    }
}
