using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly ILocalService _localService;

        public LocalController(ILocalService localService)
        {
            _localService = localService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(List<Local>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Local>>> Get()
        {
            return Ok(await _localService.ObterLocais());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        [ProducesResponseType(typeof(Local), StatusCodes.Status200OK)]
        public async Task<ActionResult<Local>> Get(int id)
        {
            var local = await _localService.ObterLocalPorId(id);
            if (local == null)
                return NotFound("Local não encontrado");
            return Ok(local);
        }

        [HttpPost]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Local), StatusCodes.Status200OK)]
        public async Task<ActionResult<Local>> Post(Local local)
        {
            var localAdicionado = await _localService.AdicionarLocal(local);
            return Ok(localAdicionado);
        }

        [HttpPut]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Local), StatusCodes.Status200OK)]
        public async Task<ActionResult<Local>> Put(Local local)
        {
            try
            {
                var localAtualizado = await _localService.AtualizarLocal(local);
                if (localAtualizado == null)
                {
                    return NotFound("Local não encontrado");
                }
                return Ok(localAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Local), StatusCodes.Status200OK)]
        public async Task<ActionResult<Local>> Delete(int id)
        {
            try
            {
                var localDeletado = await _localService.DeletarLocal(id);
                if (localDeletado == null)
                {
                    return NotFound("Local não encontrado");
                }
                return Ok(localDeletado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}