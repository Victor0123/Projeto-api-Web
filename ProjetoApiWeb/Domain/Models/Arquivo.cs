using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_api_Web.Domain.Models
{
    [Table("arquivos")]
    public class Arquivo
    {
        [Key]
        public int Id { get; private set; }
        public string S3path { get; private set; }
        public int AlunoId { get; private set; }
        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }

        public Arquivo(string S3path, int AlunoId)
        {
            this.S3path = S3path;
            this.AlunoId = AlunoId;
        }
    }
}
