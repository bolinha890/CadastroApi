using CadastroPessoasApi.service;
using CadastroPessoasApi.service;
using CadastroPessoasApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IEnumerable<pesssoaViewModel> GetAll()
        {
            var service = new servicePessoa();
            return service.GetAll();
        }
        [HttpGet("GetById/{pessoaId}")]
        public pesssoaViewModel GetById(int pessoaId)
        {
            var service = new servicePessoa();
            return service.GetById(pessoaId);
        }
        [HttpGet("GetByprimeiroNome/{primeiroNome}")]
        public pesssoaViewModel GetByprimeiroNome(string primeiroNome)
        {
            var service = new servicePessoa();
            return service.GetByprimeironome(primeiroNome);
        }
        [HttpPut("Update/{pessoaId}/{primeiroNome}")]
        public void Update(int pessoaId, string primeiroNome)
        {
            var service = new servicePessoa();
            service.Update(pessoaId, primeiroNome);
        }
        [HttpPost("Create")]
        public ActionResult Create(pesssoaViewModel pessoa)
        {
            var service = new servicePessoa();
            var resultado = service.Create(pessoa);

            if (resultado == null)
            {
                var result = new
                {
                    Success = true,
                    Data = "Cadastrado com sucesso",
                };
                return Ok(result);
            }
            else
            {
                var result = new
                {
                    Success = true,
                    Data = resultado,
                };
                return Ok(result);
            }


        }
    }
}