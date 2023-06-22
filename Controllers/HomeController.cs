using Microsoft.AspNetCore.Mvc;

namespace Emprestimo_de_livro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PaginaSobrando()
        {
            return View();
        }
    }


}
