using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Request;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Offer.CreateOffer;

namespace RocketseatAuction.API.Controllers
{
    public class OfferController : RocketseatBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        [ServiceFilter(typeof(AuthenticationUserAttribute))]
        public IActionResult CreateOffer([FromRoute]int itemId, 
            [FromBody]RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase
            )
        {
            var offer = useCase.Execute(itemId, request);
            
            return Created(string.Empty, offer);
        }
    }
}
