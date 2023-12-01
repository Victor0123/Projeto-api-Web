using Microsoft.AspNetCore.Mvc;
using Projeto_api_Web.Application.ViewModels;
using Projeto_api_Web.Domain.Models;
using Projeto_api_Web.Infrastructure.Repositories;

namespace Projeto_api_Web.Controllers
{
    [Route("/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository ?? throw new ArgumentNullException(nameof(alunoRepository));
        }

        [HttpPost]
        public IActionResult Add([FromForm] AlunoViewModel alunoView)
        {
            var aluno = new Aluno(alunoView.Nome, alunoView.Curso);

            _alunoRepository.Add(aluno);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _alunoRepository.Get();

            return Ok(alunos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAluno(int id)
        {
            var aluno = _alunoRepository.Get(id);

            return Ok(aluno);
        }
    }
}
