using hojgcfg.Data;
using hojgcfg.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hojgcfg.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StocksController : ControllerBase
	{
        private readonly StockPricesDbContext _context;

        public StocksController(StockPricesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockPrice>>> GetStockPrices()
        {
            var stockPrices = await _context.stockPrices.FromSqlRaw("EXECUTE UpdateStockPrice991").ToListAsync();

            return Ok(stockPrices);
        }
    }
}
