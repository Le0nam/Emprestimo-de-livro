using Emprestimo_de_livro.Data;
using Emprestimo_de_livro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimo_de_livro.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _db;
        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() 
        {
            IEnumerable<EmprestimoModel>emprestimos = _db.Emprestimos;  
            return View(emprestimos);
        }

        public IActionResult AdicionarEmprestimo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdicionarEmprestimo(EmprestimoModel emprestimos)
        {
            if(ModelState.IsValid) 
            {
                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
