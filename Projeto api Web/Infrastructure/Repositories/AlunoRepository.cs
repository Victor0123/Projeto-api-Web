using Projeto_api_Web.Domain.Models;

namespace Projeto_api_Web.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public List<Aluno> Get()
        {
            return _context.Alunos.ToList();
        }

        public Aluno? Get(int id)
        {
            return _context.Alunos.Find(id);
        }
    }
}
