using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using ProductApp.Services;

namespace ProductApp.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IConfiguration _configuration;

        public ProductController(IProductService productService, IConfiguration configuration)
        {
            _productService = productService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var defaultCurrency = _configuration["DefaultCurrency"]; // Get currency from settings
            var products = _productService.GetAll();

            // Return the products with currency info
            return Ok(new { products, currency = defaultCurrency });
        }

        [HttpGet("{id}")] // Correctly maps to api/products/{id}
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _productService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
    }
}
