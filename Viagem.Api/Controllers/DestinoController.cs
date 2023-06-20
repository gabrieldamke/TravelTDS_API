using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class DestinoController : ControllerBase
    {
        private readonly IDestinoService _destinoService;

        public DestinoController(IDestinoService destinoService)
        {
            _destinoService = destinoService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(List<Destino>), 200)]
        public async Task<ActionResult<List<Destino>>> Get()
        {
            return Ok(await _destinoService.ObterDestinos());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        [ProducesResponseType(typeof(Destino), 200)]
        public async Task<ActionResult<Destino>> GetById(int id)
        {
            var destino = await _destinoService.ObterDestinoPorId(id);
            if (destino == null)
                return NotFound("Destino não encontrado");
            return Ok(destino);
        }

        [HttpPost]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Destino), 200)]
        public async Task<ActionResult<Destino>> Post(Destino destino)
        {
            var destinoAdicionado = await _destinoService.AdicionarDestino(destino);
            return Ok(destinoAdicionado);
        }

        [HttpPut]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Destino), 200)]
        public async Task<ActionResult<Destino>> Put(Destino destino)
        {
            try
            {
                var destinoAtualizado = await _destinoService.AtualizarDestino(destino);
                if (destinoAtualizado == null)
                    return NotFound("Destino não encontrado");
                return Ok(destinoAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Destino), 200)]
        public async Task<ActionResult<Destino>> Delete(int id)
        {
            try
            {
                var destinoDeletado = await _destinoService.DeletarDestino(id);
                if (destinoDeletado == null)
                    return NotFound("Destino não encontrado");
                return Ok(destinoDeletado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}