using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Communication.Request;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Enums;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Offer.CreateOffer;

namespace UseCases.Tests.Offers.CreateOffer;

public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void Test_Execute_ReturnsSuccess(int itemId)
    {
        // Arrange
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(offer => offer.Price, faker => faker.Random.Decimal(1, 700));
        
        var mock = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(u => u.User()).Returns(new User());
        
        var useCase = new CreateOfferUseCase(loggedUser.Object, mock.Object);

        // Act
        var act = () => useCase.Execute(itemId, request);

        // Assert
        act.Should().NotThrow();
    }
}