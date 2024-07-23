using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace userFavorites.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context) {
        
             _context = context;
        
        }

        [HttpGet]

        public async Task<IActionResult> GetStocks()
        {
           var stock=await _context.Stocks.ToListAsync();

            return Ok(stock);

        }

        [HttpGet]
        public async Task<IActionResult> GetCrypto()
        {
            var crypto=await _context.Crypto.ToListAsync();

            return Ok(crypto);
        }

    }
}
