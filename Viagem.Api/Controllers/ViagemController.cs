using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Domain.Enums;
using Services.Services;

namespace Api.Controllers
{
    [ApiController]
    public class ViagemController : ControllerBase
    {
        private readonly IViagemService _viagemService;
        private readonly IUsuarioService _usuarioService;

        public ViagemController(IViagemService viagemService, IUsuarioService UsuarioService)
        {
            _viagemService = viagemService;
            _usuarioService = UsuarioService;
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(List<Viagem>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Viagem>>> Get()
        {
            return Ok(await _viagemService.ObterViagens());
        }

        [Authorize(Roles = "Administrador")]
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

        [HttpGet]
        [Route("api/[controller]/viagens")]
        [ProducesResponseType(typeof(List<Viagem>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Viagem>>> GetViagensDoUsuarioAutenticado()
        {
            var usuarioEmail = User.Identity?.Name;

            var usuario = await _usuarioService.ObterUsuarioPorEmail(usuarioEmail);

            if (usuario == null)
                return NotFound("Usuário não encontrado:" + usuarioEmail);

            var viagensDoUsuario = usuario.Viagens;

            return Ok(viagensDoUsuario);
        }

        [HttpGet]
        [Route("api/[controller]/viagensUsuario")]
        [ProducesResponseType(typeof(List<Viagem>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Viagem>>> GetViagensPorUsuario(string email)
        {

            var usuario = await _usuarioService.ObterUsuarioPorEmail(email);

            if (usuario == null)
                return NotFound("Usuário não encontrado:" + email);

            var viagensDoUsuario = usuario.Viagens;

            return Ok(viagensDoUsuario);
        }

        [Authorize(Roles = "Administrador, Usuario")]
        [HttpPost]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Viagem), StatusCodes.Status200OK)]
        public async Task<ActionResult<Viagem>> Post(Viagem viagem)
        {
            var viagemAdicionada = await _viagemService.AdicionarViagem(viagem);
            return Ok(viagemAdicionada);
        }

        [Authorize(Roles = "Administrador, Usuario")]
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
        [Authorize(Roles = "Administrador, Usuario")]
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