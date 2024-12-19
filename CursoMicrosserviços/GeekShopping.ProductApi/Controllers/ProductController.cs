using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(long id)
        {
            var product = await _repository.FindByID(id);
            if(product == null) return NotFound();

            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductVO>>> FindALL()
        {
            var products = await _repository.FindAll();
            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpPost()]
        public async Task<ActionResult> Create([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Create(vo);

            return Ok(product);
        }

        [HttpPut()]
        public async Task<ActionResult> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Update(vo);

            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (long id)
        {
            var status = await _repository.Delete(id);
            if(!status) return BadRequest();
            return Ok(status);
        }
    }
}
