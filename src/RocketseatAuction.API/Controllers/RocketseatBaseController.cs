using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RocketseatAuction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //Diz que a classe AuctionController é especial.
    public class RocketseatBaseController : ControllerBase
    {
    }
}
