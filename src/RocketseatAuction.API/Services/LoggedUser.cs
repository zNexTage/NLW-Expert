using System.Text;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public LoggedUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public User User()
    {
        var repo = new RocketseatAuctionDbContext();

        var token = TokenOnRequest();

        var email = FromBase64String(token);

        return repo.Users.First(user => user.Email == email);
    }
    
    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
        
        //Bearer xxxxx
        return authentication["Bearer ".Length..]; // Pega o conteúdo após a palavra bearer. 
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return Encoding.UTF8.GetString(data);
    }
}