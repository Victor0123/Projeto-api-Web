using Projeto_api_Web.Domain.Models;

namespace Projeto_api_Web.Infrastructure.Repositories
{
    public class ArquivoRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Arquivo arquivo)
        {
            _context.Arquivos.Add(arquivo);
            _context.SaveChanges();
        }
    }
}
