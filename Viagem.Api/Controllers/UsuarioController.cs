using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(List<Usuario>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return Ok(await _usuarioService.ObterUsuarios());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado");
            return Ok(usuario);
        }

        [HttpPost]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            var usuarioAdicionado = await _usuarioService.AdicionarUsuario(usuario);
            return Ok(usuarioAdicionado);
        }

        [HttpPut]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public async Task<ActionResult<Usuario>> Put(Usuario usuario)
        {
            try
            {
                var usuarioAtualizado = await _usuarioService.AtualizarUsuario(usuario);
                if (usuarioAtualizado == null)
                {
                    return NotFound("Usuário não encontrado");
                }
                return Ok(usuarioAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            try
            {
                var usuarioDeletado = await _usuarioService.DeletarUsuario(id);
                if (usuarioDeletado == null)
                {
                    return NotFound("Usuário não encontrado");
                }
                return Ok(usuarioDeletado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}