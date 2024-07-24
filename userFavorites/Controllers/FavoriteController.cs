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
        public async Task<IActionResult> AddStockFavorites([FromBody]FavoriteModel favoriteModel)
        {
            if (favoriteModel == null || string.IsNullOrEmpty(favoriteModel.UserID) || favoriteModel.stockID == 0)
            {
                return BadRequest("Invalid data.");
            }

            favoriteModel.CreatedAt = DateTime.Now;
            favoriteModel.UpdatedAt = DateTime.Now;

            await _context.StockFavorites.AddAsync(favoriteModel);
            await _context.SaveChangesAsync();
            
            return Ok("Favorilere eklendi");

        }

        [HttpPost]
        public async Task<IActionResult> AddCryptoFavorites([FromBody]CryptoFavModel cryptoFavModel)
        {


            if (cryptoFavModel is null || string.IsNullOrEmpty(cryptoFavModel.UserID)||cryptoFavModel.cryptoID==0)
            {
                return BadRequest("Invalid Data");
            }

            cryptoFavModel.CreatedAt= DateTime.Now;
            cryptoFavModel.UpdatedAt= DateTime.Now;

            await _context.CryptoFavorites.AddAsync(cryptoFavModel);
            await _context.SaveChangesAsync();

            return StatusCode(200, new {Message="Favoriye Ekleme başarılı!"});

        }
    }
}
