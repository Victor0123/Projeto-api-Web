using Projeto_api_Web.Domain.Models;

namespace Projeto_api_Web.Infrastructure.Repositories
{
    public interface IAlunoRepository
    {
        void Add(Aluno aluno);

        List<Aluno> Get();

        Aluno? Get(int id);
    }
}
