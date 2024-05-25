using AutoMapper;
using CloudinaryDotNet;
using IceCreamRecipe.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Users;
using Repositories.Users;

namespace Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepo _userRepo;
    
    private readonly IMapper _mapper;

    public UserController(IUserRepo user,IMapper mapper)
    {
        _userRepo = user;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> getAllAccounts([FromQuery] PaginationReq pageReq)
    {
        return Ok(await _userRepo.FindAll(pageReq));
    }

    [HttpGet("/Current")]
    [Authorize]
    public async Task<IActionResult> getCurrentAccounts()
    {
        var name = User.Identity.Name;
        var user = await _userRepo.GetUserDetail(name);
        return Ok(_mapper.Map<UserRes>(user));
    }
    
    
}