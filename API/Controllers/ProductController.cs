using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _repo.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);

            if(product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}
