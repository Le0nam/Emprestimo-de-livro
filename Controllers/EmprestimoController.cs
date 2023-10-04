using Emprestimo_de_livro.Data;
using Emprestimo_de_livro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.VisualBasic;
using PagedList;
using System.Data.SqlTypes;
using System.Linq;

namespace Emprestimo_de_livro.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _db;
        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? pagina)
        {
            
            IEnumerable<EmprestimoModel> emprestimos = _db.Emprestimos;

            int paginaTamanho = 1;
            int paginaNumero = (pagina ?? 1);

            return View(emprestimos.ToPagedList(paginaNumero, paginaTamanho));
        }
        public IActionResult AdicionarEmprestimo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdicionarEmprestimo(EmprestimoModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                
                _db.Emprestimos.Add(emprestimos);
               
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {   
            if(id  == 0 || id == null)
            {
                return NotFound();
            }
            EmprestimoModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            
            if (emprestimo == null) 
            {
                return NotFound();
            }
            return View(emprestimo);
        }
        [HttpPost]
        public IActionResult Editar(EmprestimoModel emprestimo) 
        {
            if (ModelState.IsValid) 
            {
                

                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(emprestimo);
        }
        public IActionResult Remover(int id)
        {
            if (id == 0 || id == null)
            {
                
            }

            EmprestimoModel emprestimo = _db.Emprestimos
                .Where(x => x.Id == id)
                .FirstOrDefault();
            emprestimo.Verificação = true;
            //_db.Remove(emprestimo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CancelarRemoção() 
        {
            IEnumerable<EmprestimoModel>emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }
        public IActionResult Restaurar(int id) 
        {
            if (id == 0 || id == null)
            {

            }
            EmprestimoModel emprestimo = _db.Emprestimos.Where(x => x.Id == id).FirstOrDefault();
            emprestimo.Verificação = false;
            _db.SaveChanges();
            return RedirectToAction("CancelarRemoção");
        }
        //[HttpGet]
        //public Task<IActionResul> Index(int id)
        //{
            
        //        if (id == 0 || id == null)
        //        {
        //            return NotFound();
        //        }
        //        EmprestimoModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

        //        if (emprestimo == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(emprestimo);

        //}
    }
}