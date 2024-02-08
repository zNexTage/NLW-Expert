using System.Text;
using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Communication.Request;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Offer.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;
    public CreateOfferUseCase(LoggedUser loggedUser)
    {
        _loggedUser = loggedUser;
    }
    
    public Entities.Offer Execute(int itemId, RequestCreateOfferJson request)
    {
        var repo = new RocketseatAuctionDbContext();

        var user = _loggedUser.User();

        var offer = new Entities.Offer()
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };
        
        repo.Offers.Add(offer);
        repo.SaveChanges();

        return offer;
    }
    
    
}