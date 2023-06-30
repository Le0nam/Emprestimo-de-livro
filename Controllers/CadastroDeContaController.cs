using Emprestimo_de_livro.Data;
using Emprestimo_de_livro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.Linq;

namespace Emprestimo_de_livro.Controllers
{
    public class CadastroDeContaController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult Editar() 
        {
            return View();
        }
        public IActionResult Remover()
        {
            
            return RedirectToAction("Index");
        }
    }
}
