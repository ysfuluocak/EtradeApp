using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.CartItemDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        ICartService _cartService;
        ICartItemService _cartItemService;

        public CartsController(ICartService cartService, ICartItemService cartItemService)
        {
            _cartService = cartService;
            _cartItemService = cartItemService;
        }

        [HttpGet("getallcart")]
        public IActionResult GetAllCart()
        {
            var result = _cartService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcartbyid")]
        public IActionResult GetCart(int Id)
        {
            var result = _cartService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addcartitem")]
        public IActionResult Add(CreateCartItemDto createCartItemDto)
        {
            var result = _cartItemService.Add(createCartItemDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updatecartitem")]
        public IActionResult Update(UpdateCartItemDto updateCartItemDto)
        {
            var result = _cartItemService.Update(updateCartItemDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletecartitem")]
        public IActionResult Delete(CreateCartItemDto createCartItemDto)
        {
            var result = _cartItemService.Delete(createCartItemDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addtocart")]
        public IActionResult Add(AddToCartDto addToCartDto)
        {
        var result = _cartItemService.AddToCart(addToCartDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
