namespace Emprestimo_de_livro.Models
{
    public class ContaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RG { get; set; }
        public int CPF { get; set; }
        public enum Opcões
        { 
            Aprovado = 0,
            Negado = 1,
            EmAnalise = 2        
        }
        public virtual Opcões Situação { get; set; }
    }
}