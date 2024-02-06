using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auction.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Entities.Auction? Execute()
    {
        var repo = new RocketseatAuctionDbContext();

        var today = DateTime.Now;

        return repo
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}