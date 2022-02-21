using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockPriceUpdateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockPriceUpdateAPIController : ControllerBase
    {
        private static List<Products> products = new List<Products>{};
        
        private readonly DataContext _context;

        public StockPriceUpdateAPIController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProduct()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Products>>> GetId(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return BadRequest("Product not found !");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Products>>> PostProduct(Products product) 
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPut("Stock")]
        public async Task<ActionResult<List<Products>>> UpdateStock(int id, int newStock)
        {
            var DbProduct = await _context.Products.FindAsync(id);
            if (DbProduct == null)
                return BadRequest("Product not found !");

            DbProduct.Stock = newStock;
            await _context.SaveChangesAsync();

            return Ok(DbProduct);

        }

        [HttpPut("Price")]
        public async Task<ActionResult<List<Products>>> UpdatePrice(int id, double newPrice)
        {
            var DbProduct = await _context.Products.FindAsync(id);
            if (DbProduct == null)
                return BadRequest("Product not found !");

            DbProduct.Price = newPrice;
            await _context.SaveChangesAsync();

            return Ok(DbProduct);

        }

        [HttpDelete]
        public async Task<ActionResult<List<Products>>> RemoveProduct(int id) 
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return BadRequest("Product not found !");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

    }
}
