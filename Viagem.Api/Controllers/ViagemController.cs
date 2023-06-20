using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class ViagemController : ControllerBase
    {
        private readonly IViagemService _viagemService;

        public ViagemController(IViagemService viagemService)
        {
            _viagemService = viagemService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(List<Viagem>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Viagem>>> Get()
        {
            return Ok(await _viagemService.ObterViagens());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        [ProducesResponseType(typeof(Viagem), StatusCodes.Status200OK)]
        public async Task<ActionResult<Viagem>> GetById(int id)
        {
            var viagem = await _viagemService.ObterViagemPorId(id);
            if (viagem == null)
                return NotFound("Viagem não encontrada");
            return Ok(viagem);
        }

        [HttpPost]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Viagem), StatusCodes.Status200OK)]
        public async Task<ActionResult<Viagem>> Post(Viagem viagem)
        {
            var viagemAdicionada = await _viagemService.AdicionarViagem(viagem);
            return Ok(viagemAdicionada);
        }

        [HttpPut]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Viagem), StatusCodes.Status200OK)]
        public async Task<ActionResult<Viagem>> Put(Viagem viagem)
        {
            try
            {
                var viagemAtualizada = await _viagemService.AtualizarViagem(viagem);
                if (viagemAtualizada == null)
                {
                    return NotFound("Viagem não encontrada");
                }
                return Ok(viagemAtualizada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Viagem), StatusCodes.Status200OK)]
        public async Task<ActionResult<Viagem>> Delete(int id)
        {
            try
            {
                var viagemDeletada = await _viagemService.DeletarViagem(id);
                if (viagemDeletada == null)
                {
                    return NotFound("Viagem não encontrada");
                }
                return Ok(viagemDeletada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}