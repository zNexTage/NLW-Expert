using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Enums;
using RocketseatAuction.API.UseCases.Auction.GetCurrent;

namespace UseCases.Tests.Auctions.GetCurrent;

public class GetCurrentUseCaseTest
{
    [Fact]
    public void Test_Execute_ReturnsSuccess()
    {
        // Arrange
        var entity = new Faker<Auction>()
            .RuleFor(auction => auction.Id, faker => faker.Random.Number(1, 700))
            .RuleFor(auction => auction.Name, faker => faker.Lorem.Word())
            .RuleFor(auction => auction.Starts, faker => faker.Date.Past())
            .RuleFor(auction => auction.Ends, faker => faker.Date.Future())
            .RuleFor(auction => auction.Items, (faker, auction) => new List<Item>()
            {
                new Item()
                {
                    Id = faker.Random.Number(1, 700),
                    Name = faker.Commerce.ProductName(),
                    Brand = faker.Commerce.Department(),
                    BasePrice = faker.Random.Decimal(50, 1000),
                    Condition = faker.PickRandom<Condition>(),
                    AuctionId = auction.Id
                }
            }).Generate();
        
        var mock = new Mock<IAuctionRepository>();
        mock.Setup(repo => repo.GetCurrent())
            .Returns(entity);
        
        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        // Act
        var auctionResult = useCase.Execute();

        // Assert
        auctionResult.Should().NotBeNull();
        auctionResult.Id.Should().Be(entity.Id);
        auctionResult.Name.Should().Be(entity.Name);
    }
    
}