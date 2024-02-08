using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.Repositories.DataAccess;

namespace RocketseatAuction.API.UseCases.Auction.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository; // Nós só precisamos de uma classe que implementa IAuctionRepository

    public GetCurrentAuctionUseCase(IAuctionRepository repository)
    {
        _repository = repository;
    }
    
    public Entities.Auction? Execute()
    {
        return _repository.GetCurrent();
    }
}