using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly IRestauranteService _restauranteService;

        public RestauranteController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        [Route("api/[controller]")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Restaurante>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Restaurante>>> Get()
        {
            return Ok(await _restauranteService.ObterRestaurantes());
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Restaurante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restaurante>> GetById(int id)
        {
            var restaurante = await _restauranteService.ObterRestaurantePorId(id);
            if (restaurante == null)
            {
                return NotFound("Restaurante não encontrado");
            }
            return Ok(restaurante);
        }

        [Route("api/[controller]")]
        [HttpPost]
        [Authorize(Roles = "Administrador, Usuario")]
        [ProducesResponseType(typeof(Restaurante), StatusCodes.Status200OK)]
        public async Task<ActionResult<Restaurante>> Post(Restaurante restaurante)
        {
            var novoRestaurante = await _restauranteService.AdicionarRestaurante(restaurante);
            return Ok(novoRestaurante);
        }

        [Route("api/[controller]")]
        [HttpPut]
        [Authorize(Roles = "Administrador, Usuario")]
        [ProducesResponseType(typeof(Restaurante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restaurante>> Put(Restaurante restaurante)
        {
            try
            {
                var restauranteAtualizado = await _restauranteService.AtualizarRestaurante(restaurante);
                if (restauranteAtualizado == null)
                {
                    return NotFound("Restaurante não encontrado");
                }
                return Ok(restauranteAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/[controller]/{id}")]
        [HttpDelete]
        [Authorize(Roles = "Administrador, Usuario")]
        [ProducesResponseType(typeof(Restaurante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restaurante>> Delete(int id)
        {
            try
            {
                var restaurante = await _restauranteService.DeletarRestaurante(id);
                if (restaurante == null)
                {
                    return NotFound("Restaurante não encontrado");
                }
                return Ok(restaurante);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}