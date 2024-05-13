using BL.Handler.UserHandler.UserRequests;
using BL.Interfaces;
using Core.Exeptions;
using Microsoft.AspNetCore.Mvc;

namespace notesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IServiceUser service;

    public UserController(IServiceUser service)
    {
        this.service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(UserAddRequest request)
    {
        try
        {
            return Ok(await service.AddUserAsync(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await service.GetAllAsync());
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(Guid userId)
    {
        try
        {
            return Ok(await service.GetByIdAsync(userId));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("ChangeEmail")]
    public async Task<IActionResult> ChangeEmail(ChangeEmailRequest request)
    {
        try
        {
            return Ok(await service.ChangeEmail(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("ChangeName")]
    public async Task<IActionResult> ChangeName(ChangeNameUserRequest request)
    {
        try
        {
            return Ok(await service.ChangeName(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        try
        {
            return Ok(await service.ChangePassword(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("ChangeUserName")]
    public async Task<IActionResult> ChangeUserName(ChangeUserNameRequest request)
    {
        try
        {
            return Ok(await service.ChangeUserName(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> SoftDeleteUser(Guid id)
    {
        try
        {
            return Ok(await service.DeleteUser(id));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
