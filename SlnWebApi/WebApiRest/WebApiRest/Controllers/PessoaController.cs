using Microsoft.AspNetCore.Mvc;
using WebApiRest.Model;
using WebApiRest.Services;

namespace WebApiRest.Controllers
{
    public class PessoaController : ControllerBase
    {
        private IPessoaService _pessoaService;

        private readonly ILogger<PessoaController> _logger;
        public PessoaController(ILogger<PessoaController> logger, IPessoaService pessoaService)
        {
            _logger = logger;
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public  IActionResult Get()
        {
            return Ok(_pessoaService.FindAll());
        }


        [HttpGet("{Id}")]
        public IActionResult Get(long Id)
        {
            var pessoa = _pessoaService.FindById(Id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaService.Create(pessoa));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaService.Update(pessoa));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            _pessoaService.Delete(Id);
            return NoContent();
        }
    }
}
