using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class AtracaoTuristicaController : Controller
    {
        private readonly IAtracaoTuristicaService _atracaoTuristicaService;
        public AtracaoTuristicaController(IAtracaoTuristicaService atracaoTuristicaService)
        {
            _atracaoTuristicaService = atracaoTuristicaService;
        }
        [Route("api/[controller]")]
        [HttpGet]
        [ProducesResponseType(typeof(Domain.Entities.AtracaoTuristica), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Domain.Entities.AtracaoTuristica>>> Get()
        {
            return Ok(await _atracaoTuristicaService.ObterAtracoesTuristicas());
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Domain.Entities.AtracaoTuristica), StatusCodes.Status200OK)]
        public async Task<ActionResult<Domain.Entities.AtracaoTuristica>> Get(int id)
        {
            var atracao = await _atracaoTuristicaService.ObterAtracoesTuristicasId(id);
            if (atracao == null)
                return NotFound("Atração Turística não encontrada");
            return Ok(atracao);
        }

        [Route("api/[controller]")]
        [HttpPost]
        [ProducesResponseType(typeof(Domain.Entities.AtracaoTuristica), StatusCodes.Status200OK)]
        public async Task<ActionResult<Domain.Entities.AtracaoTuristica>> Post(AtracaoTuristica atracaoTuristica)
        {
            var atracao = await _atracaoTuristicaService.AdicionarAtracaoTuristica(atracaoTuristica);
            return Ok(atracao);
        }

        [Route("api/[controller]")]
        [HttpPut]
        [ProducesResponseType(typeof(Domain.Entities.AtracaoTuristica), StatusCodes.Status200OK)]
        public async Task<ActionResult<Domain.Entities.AtracaoTuristica>> Put(AtracaoTuristica atracaoTuristica)
        {
            try
            {
                var atracao = await _atracaoTuristicaService.AtualizarAtracaoTuristica(atracaoTuristica);
                if(atracao == null)
                {
                    return NotFound("Atração não encontrada");
                }
                return Ok(atracao);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/[controller]")]
        [HttpDelete]
        [ProducesResponseType(typeof(Domain.Entities.AtracaoTuristica), StatusCodes.Status200OK)]

        public async Task<ActionResult<Domain.Entities.AtracaoTuristica>> Delete(int id)
        {
            try { 
            var atracao = await _atracaoTuristicaService.DeletarAtracaoTuristica(id);
            if(atracao == null)
            {
                return NotFound("Atração não encontrada");
            }
            return Ok(atracao);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
