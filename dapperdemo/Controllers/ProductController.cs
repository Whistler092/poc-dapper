using System.Collections.Generic;
using System.Threading.Tasks;
using dapperdemo.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dapperdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return await productRepository.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var data = await productRepository.GetById(id);

            if (data is null)
                return NotFound();

            return Ok(data);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            var data = await productRepository.Add(product);
            return Ok(data);
        }
 

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await productRepository.Delete(id);
            return Ok();
        }
    }
}
