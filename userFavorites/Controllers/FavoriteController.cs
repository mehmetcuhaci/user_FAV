using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using userFavorites.Models;

namespace userFavorites.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public FavoriteController(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context; 
        }


        [HttpPost]
        public async Task<IActionResult> AddFavorites([FromBody]FavoriteModel favoriteModel)
        {
            if (favoriteModel == null || string.IsNullOrEmpty(favoriteModel.UserID) || favoriteModel.stockID == 0)
            {
                return BadRequest("Invalid data.");
            }

            favoriteModel.CreatedAt = DateTime.Now;
            favoriteModel.UpdatedAt = DateTime.Now;

            await _context.Favorites.AddAsync(favoriteModel);
            await _context.SaveChangesAsync();
            
            return Ok("Favorilere eklendi");

        }


    }
}
