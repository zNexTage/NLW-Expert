using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly RocketseatAuctionDbContext _context;

    public UserRepository(RocketseatAuctionDbContext context)
    {
        _context = context;
    }

    public bool ExistsUserWithEmail(string email)
    {
        return _context.Users.Any(user => user.Email == email);
    }

    public User GetByEmail(string email)
    {
        return _context.Users.First(user => user.Email == email);
    }
}