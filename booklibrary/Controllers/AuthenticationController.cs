using booklibrary.Data;
using booklibrary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace booklibrary.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<LibraryUser> _userManager;
    public AuthenticationController(UserManager<LibraryUser>  userManager)
    {
        this._userManager = userManager;
    }
    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Register([FromBody] RegistrationModel registrationModel)
    {
        var existingUser = this._userManager.FindByNameAsync(registrationModel.Username);
        if (existingUser != null)
            return Conflict("User Already Exists");
        var newUser = new LibraryUser
        {
            UserName = registrationModel.Username,
            Email = registrationModel.Email,
            Reviews = new List<BookReview>(),
              // A random value that must change whenever a users credentials change (password
        //     changed, login removed)
            SecurityStamp = Guid.NewGuid().ToString()
        };
        var result = await this._userManager.CreateAsync(newUser, registrationModel.Password);
        if (result.Succeeded)
            return Ok(result);
        else return StatusCode(StatusCodes.Status500InternalServerError);
    }
}