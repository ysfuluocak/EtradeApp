using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

       // [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public IActionResult Add(CreateProduct createProduct)
        {
            var result = _productService.Add(createProduct);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CreateProduct createProduct)
        {
            var result = _productService.Update(createProduct);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
