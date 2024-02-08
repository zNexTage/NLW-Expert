using System.Text;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.Services;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repo;
    
    public LoggedUser(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _repo = userRepository;
    }
    
    public User User()
    {

        var token = TokenOnRequest();

        var email = FromBase64String(token);

        return _repo.GetByEmail(email);
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