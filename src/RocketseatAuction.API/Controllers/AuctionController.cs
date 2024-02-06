using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auction.GetCurrent; // Utilizando uma classe que está em outro local.

// namespace serve para organizar nossa aplicação. Serve para dizer onde está nossas classes.
namespace RocketseatAuction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Diz que a classe AuctionController é especial.
    public class AuctionController : ControllerBase
    {
        //Um controller agrupa vários endpoints
        
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction()
        {
            var useCase = new GetCurrentAuctionUseCase();
            var result = useCase.Execute();

            if (result is null)
            {
                return NoContent();
            }
            
            return Ok(result);
        }
    }
}
