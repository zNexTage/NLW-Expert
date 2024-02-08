using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly IUserRepository _repo;
    public AuthenticationUserAttribute(IUserRepository repo)
    {
        _repo = repo;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);

            var email = FromBase64String(token);

            var exists = _repo.ExistsUserWithEmail(email);

            if (!exists)
            {
                context.Result = new UnauthorizedObjectResult("E-mail not valid");
            }
        }
        catch (Exception e)
        {
            context.Result = new UnauthorizedObjectResult(e.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authentication))
        {
            throw new Exception("Token is missing");
        }
        //Bearer xxxxx
        return authentication["Bearer ".Length..]; // Pega o conteúdo após a palavra bearer. 
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return Encoding.UTF8.GetString(data);
    }
}