using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using userFavorites.Dtos;
using userFavorites.Models;

namespace userFavorites.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto request, CancellationToken cancellationToken)
        {
            //Db kayıt işlemi

            AppUser appUser = new()
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            IdentityResult result = await userManager.CreateAsync(appUser, request.Password);

            var token = await userManager.GenerateEmailConfirmationTokenAsync(appUser);


            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(s => s.Description));
            }
            return StatusCode(200, $"Kayıt Başarılı \n" + token);
        }


        [HttpGet]
        public async Task<IActionResult> LogIn(LogInDto loginDto,CancellationToken cancellationToken)
        {

        }
    }
}
