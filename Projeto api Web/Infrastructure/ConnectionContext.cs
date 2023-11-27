using Microsoft.EntityFrameworkCore;
using Projeto_api_Web.Domain.Models;

namespace Projeto_api_Web.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=webapi;" +
                "User Id=postgres;" +
                "Password=docker;"));
        }
    }
}
