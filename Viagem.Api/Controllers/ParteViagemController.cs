using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    public class ParteViagemController : ControllerBase
    {
        private readonly IParteViagemService _parteViagemService;

        public ParteViagemController(IParteViagemService parteViagemService)
        {
            _parteViagemService = parteViagemService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(List<ParteViagem>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ParteViagem>>> Get()
        {
            return Ok(await _parteViagemService.ObterPartesViagem());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        [ProducesResponseType(typeof(ParteViagem), StatusCodes.Status200OK)]
        public async Task<ActionResult<ParteViagem>> Get(int id)
        {
            var parteViagem = await _parteViagemService.ObterParteViagemPorId(id);
            if (parteViagem == null)
                return NotFound("Parte da viagem não encontrada");
            return Ok(parteViagem);
        }

        [HttpPost]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(ParteViagem), StatusCodes.Status200OK)]
        public async Task<ActionResult<ParteViagem>> Post(ParteViagem parteViagem)
        {
            var parteViagemAdicionada = await _parteViagemService.AdicionarParteViagem(parteViagem);
            return Ok(parteViagemAdicionada);
        }

        [HttpPut]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(ParteViagem), StatusCodes.Status200OK)]
        public async Task<ActionResult<ParteViagem>> Put(ParteViagem parteViagem)
        {
            try
            {
                var parteViagemAtualizada = await _parteViagemService.AtualizarParteViagem(parteViagem);
                if (parteViagemAtualizada == null)
                {
                    return NotFound("Parte da viagem não encontrada");
                }
                return Ok(parteViagemAtualizada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(ParteViagem), StatusCodes.Status200OK)]
        public async Task<ActionResult<ParteViagem>> Delete(int id)
        {
            try
            {
                var parteViagemDeletada = await _parteViagemService.DeletarParteViagem(id);
                if (parteViagemDeletada == null)
                {
                    return NotFound("Parte da viagem não encontrada");
                }
                return Ok(parteViagemDeletada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}