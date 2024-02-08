using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts;

public interface IOfferRepository
{
    public Offer Add(Offer offer);
}