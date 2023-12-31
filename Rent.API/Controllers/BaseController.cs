using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Rent.Domain.Exceptions.Auth;

namespace Rent.API.Controllers;

public abstract class BaseController : ControllerBase
{
    protected Guid GetUserId()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        Guid userId;
        var userIdOk = Guid.TryParse(userIdString, out userId);
        if (!userIdOk)
        {
            throw new UserIdIncorrectException(userIdString ?? "");
        }
        return userId;
    }
}