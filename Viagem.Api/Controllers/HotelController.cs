using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace Api.Controllers
{
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(List<Hotel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Hotel>>> Get()
        {
            var hoteis = await _hotelService.ObterHoteis();
            return Ok(hoteis);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        public async Task<ActionResult<Hotel>> GetById(int id)
        {
            var hotel = await _hotelService.ObterHotelPorId(id);
            if (hotel == null)
                return NotFound("Hotel não encontrado");
            return Ok(hotel);
        }

        [HttpPost]
        [Route("api/[controller]")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        public async Task<ActionResult<Hotel>> Post(Hotel hotel)
        {
            var hotelAdicionado = await _hotelService.AdicionarHotel(hotel);
            return Ok(hotelAdicionado);
        }

        [HttpPut]
        [Route("api/[controller]")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        public async Task<ActionResult<Hotel>> Put(Hotel hotel)
        {
            try
            {
                var hotelAtualizado = await _hotelService.AtualizarHotel(hotel);
                if (hotelAtualizado == null)
                {
                    return NotFound("Hotel não encontrado");
                }
                return Ok(hotelAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        public async Task<ActionResult<Hotel>> Delete(int id)
        {
            try
            {
                var hotelDeletado = await _hotelService.DeletarHotel(id);
                if (hotelDeletado == null)
                {
                    return NotFound("Hotel não encontrado");
                }
                return Ok(hotelDeletado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}