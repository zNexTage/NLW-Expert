using Microsoft.AspNetCore.Mvc; // Utilizando uma classe que está em outro local.

// namespace serve para organizar nossa aplicação. Serve para dizer onde está nossas classes.
namespace RocketseatAuction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Diz que a classe AuctionController é especial.
    public class AuctionController : ControllerBase
    {
        //Um controller agrupa vários endpoints
        
        [HttpGet]
        public IActionResult GetCurrentAuction()
        {
            return Ok("Dr Antocopio");
        }
    }
}
