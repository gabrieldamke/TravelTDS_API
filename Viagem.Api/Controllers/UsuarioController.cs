using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(List<Usuario>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return Ok(await _usuarioService.ObterUsuarios());
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        [Route("api/[controller]/{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado");
            return Ok(usuario);
        }

        [HttpGet]
        [Route("api/[controller]/email")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public async Task<ActionResult<Usuario>> GetByEmail(string email)
        {
            var usuario = await _usuarioService.ObterUsuarioPorEmail(email);
            if (usuario == null)
                return NotFound("Usuário não encontrado");
            return Ok(usuario);
        }

        [HttpGet]
        [Route("api/[controller]/verificaremailexiste")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> VerificarEmailExiste(string email)
        {
            var validar = await _usuarioService.VerificarEmailExiste(email);
            if (validar == null)
                return NotFound("Email não encontrado");

            return Ok(validar);
        }

        [HttpGet]
        [Route("api/[controller]/validar")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> validarLoginUsuario([FromQuery] Authentication auth)
        {
            var usuario = await _usuarioService.ObterUsuarioPorEmail(auth.email);
            if (usuario == null)
                return NotFound("Usuário não encontrado");
            try
            {
                var resultado = await _usuarioService.validarLogin(auth);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            try
            {
                var usuarioAdicionado = await _usuarioService.AdicionarUsuario(usuario);
                return Ok(usuarioAdicionado);
            }
            catch (Exception ex)
            {
                // Verificar se a exceção é devido ao e-mail já existir
                if (ex.Message == "O e-mail informado já está em uso.")
                {
                    return Conflict("O e-mail informado já está em uso. Escolha outro e-mail.");
                }

                // Caso seja outra exceção, você pode retornar um código de erro apropriado
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao adicionar o usuário.");
            }
        }

        [HttpPut]
        [Authorize(Roles = "Administrador, Usuario")]
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
        [Authorize(Roles = "Administrador, Usuario")]
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