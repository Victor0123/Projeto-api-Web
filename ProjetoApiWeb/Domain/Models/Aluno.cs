using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_api_Web.Domain.Models
{
    [Table("alunos")]
    public class Aluno
    {
        [Key]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Curso { get; private set; }
        //public string? Arquivos { get; private set; }

        public Aluno(string Nome, string Curso)
        {
            this.Nome = Nome;
            this.Curso = Curso;
            //this.Arquivos = Arquivos;
        }
    }
}
