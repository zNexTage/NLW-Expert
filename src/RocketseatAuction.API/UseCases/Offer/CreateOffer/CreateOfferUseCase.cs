using System.Text;
using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Communication.Request;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.Repositories.DataAccess;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Offer.CreateOffer;

public class CreateOfferUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IOfferRepository _repository;
    public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository repository)
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }
    
    public Entities.Offer Execute(int itemId, RequestCreateOfferJson request)
    {
        var user = _loggedUser.User();

        var offer = new Entities.Offer()
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };

        return _repository.Add(offer);
    }
}