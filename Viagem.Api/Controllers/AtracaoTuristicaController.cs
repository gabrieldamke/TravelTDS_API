using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AtracaoTuristicaController : Controller
    {
        private readonly IAtracaoTuristicaService _atracaoTuristicaService;
        public AtracaoTuristicaController(IAtracaoTuristicaService atracaoTuristicaService)
        {
            _atracaoTuristicaService = atracaoTuristicaService;
        }
        [Route("api/[controller]")]
        [HttpGet]
        public async Task<ActionResult<List<Domain.Entities.AtracaoTuristica>>> Get()
        {
            return Ok(await _atracaoTuristicaService.ObterAtracoesTuristicas());
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public async Task<ActionResult<Domain.Entities.AtracaoTuristica>> Get(int id)
        {
            var atracao = await _atracaoTuristicaService.ObterAtracoesTuristicasId(id);
            if (atracao == null)
                return BadRequest("Atração Turística não encontrada");
            return Ok(atracao);
        }

        [Route("api/[controller]")]
        [HttpPost]
        public async Task<ActionResult<Domain.Entities.AtracaoTuristica>> Post(AtracaoTuristica atracaoTuristica)
        {
            var atracao = await _atracaoTuristicaService.AdicionarAtracaoTuristica(atracaoTuristica);
            return Ok(atracao);
        }
    }
}
