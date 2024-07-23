using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using userFavorites.Dtos;
using userFavorites.Models;

namespace userFavorites.Controllers
{
    [Route("api/[controller]/[action]")]
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


        [HttpPost]
        public async Task<IActionResult> LogIn(LoginDto loginDto,CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(p =>

            p.Email == loginDto.UserNameorOrEmail || p.UserName == loginDto.UserNameorOrEmail, cancellationToken
            );

            if (appUser is null)
            {
                return BadRequest(new { Message = "Kullanıcı bulunamadı!" });
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.CheckPasswordSignInAsync(appUser, loginDto.password, true);



            if (result.IsNotAllowed)
            {
                return StatusCode(500, "Mail adresi onaylı değil!");
            }

            if (!result.Succeeded)
            {
                return StatusCode(500, "Şifre Yanlış!");
            }

            var logresponse = new
            {
                userId = appUser.Id
            };
            return Ok(logresponse);

        }
    }
}
