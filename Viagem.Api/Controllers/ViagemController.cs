using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{
    public class ViagemController : Controller
    {
        [Route("api/[controller]")]
        [HttpGet]
        public async Task<ActionResult<List<Domain.Entities.Viagem>>> Get()
        {
            var viagens = new List<Domain.Entities.Viagem>();
            return Ok(viagens);
        }
    }
}
