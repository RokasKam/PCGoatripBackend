using System.Security.Claims;
using Academy.Core.Interfaces;
using Academy.Core.Requests.Place;
using Academy.Core.Requests.User;
using Academy.Core.Responses.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academy.API.Controllers;

public class UsersController : BaseController
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;
    
    public UsersController(IAuthService authService, IUserService userService, IJwtService jwtService)
    {
        _authService = authService;
        _userService = userService;
        _jwtService = jwtService;
    }
    
    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        var user = _authService.Login(request);
        var jwt = _jwtService.BuildJwt(user);

        return Ok(jwt);
    }
    
    [HttpPost]
    public IActionResult Register(RegisterRequest request)
    {
        var response = _authService.Register(request);
        return Ok(response);
    }
    
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetMe()
    {
        var user = _userService.GetById(Guid.Parse(User.FindFirstValue(ClaimTypes.Sid)));
        return Ok(user);
    }
    
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetAllUserPlace([FromQuery] PlacesParameters placesParameters)
    {
        var id = Guid.Parse(User.FindFirstValue(ClaimTypes.Sid));
        return Ok(_userService.GetAllUserPlaces(id, placesParameters));
    }
    
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult AddLikedPlace(Guid placeId)
    {
        var id = Guid.Parse(User.FindFirstValue(ClaimTypes.Sid));
        _userService.AddLikedPlace(id, placeId);
        return Ok();
    }
    
    [HttpDelete]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult RemoveLikedPlace(Guid placeId)
    {
        var id = Guid.Parse(User.FindFirstValue(ClaimTypes.Sid));
        _userService.RemoveLikedPlace(id, placeId);
        return Ok();
    }
}