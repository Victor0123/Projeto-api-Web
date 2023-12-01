using Microsoft.AspNetCore.Mvc;
using Projeto_api_Web.Application.ViewModels;
using Projeto_api_Web.Domain.Models;
using Projeto_api_Web.Infrastructure.Repositories;
using Projeto_api_Web.Services;

namespace Projeto_api_Web.Controllers
{
    public class FileController : ControllerBase
    {
        [HttpPost]
        [Route("/arquivos")]
        public async Task<ActionResult> Upload([FromForm] ArquivoViewModel files)

        {
            foreach (var file in files.Arquivos)
            {
                string bucket = "rossinitestes3";
                string key = "";

                if (file.Length > 0)
                {
                    if (file.ContentType == "image/png" || file.ContentType == "image/jpeg")
                    {
                        key = "images/" + Guid.NewGuid();
                    }
                    else
                    {
                        key = "files/" + Guid.NewGuid();
                    }

                    var S3path = key;
                    var arquivo = new Arquivo(S3path, files.AlunoId);

                    var _query = new ArquivoRepository();
                    _query.Add(arquivo);

                    var amazon = new AmazonS3Service();
                    var uploadFile = await amazon.UploadFileAsync(bucket, key, file);

                    if (uploadFile == false)
                    {
                        return BadRequest();
                    }
                }
            }

            return Ok();
        }
    }
}
