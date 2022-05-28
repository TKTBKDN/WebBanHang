using Commerce.Repository.Entities;
using Commerce.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Commerce.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetProductsQuery();
            return Ok(products);
        }

        [HttpPost("postProduct")]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            await _productService.Add(product);
            return Ok();
        }
    }
}
