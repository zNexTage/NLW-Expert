using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts;

public interface IAuctionRepository
{
    public Auction? GetCurrent();
}