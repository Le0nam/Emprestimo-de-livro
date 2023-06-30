using System.ComponentModel.DataAnnotations;

namespace Emprestimo_de_livro.Models
{
    public class EmprestimoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Recebedor")]
        public string Recebedor { get; set; }
        [Required(ErrorMessage = "Digite o nome do Fornecedor")]
        public string Fornecedor { get; set; }
        [Required(ErrorMessage = "Digite o nome do Livro")]
        public string Livro { get; set;}
        public bool Verificação { get; set; }
        public DateTime DataUltimaAtualização { get; set; } = DateTime.Now;

    }
}