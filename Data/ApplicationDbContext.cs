using Emprestimo_de_livro.Models;
using Microsoft.EntityFrameworkCore;

namespace Emprestimo_de_livro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


        public DbSet<EmprestimoModel> Emprestimos { get; set; }
    }
}
