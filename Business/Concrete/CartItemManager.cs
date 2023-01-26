using Business.Abstract;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.Dtos.CartItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        ICartItemDal _cartItemDal;
        IProductService _productService;
        ICartService _cartService;
        public CartItemManager(ICartItemDal cartItemDal,IProductService productService, ICartService cartService)
        {
            _cartItemDal = cartItemDal;
            _productService = productService;
            _cartService = cartService;
        }

        public IResult Add(CreateCartItemDto createCartItemDto)
        {
            var cartItem = new CartItem()
            {
                ProductId = createCartItemDto.ProductId,
                Quantity = createCartItemDto.Quantity,
                Cart = new()
                {

                }
            };

             _cartItemDal.Add(cartItem);
            return new SuccessResult();
        }

        public IResult AddToCart(AddToCartDto addToCartDto)
        {
            var cartItem = _cartItemDal.Get(ci=>ci.CartItemId == addToCartDto.CartItemId);
            var product = _productService.GetById(cartItem.ProductId);
            cartItem.Cart = new Cart()
            {
                CreatedAt = DateTime.Now,
                TotalPrice = product.Data.Price * cartItem.Quantity
            };
            _cartItemDal.Update(cartItem);
            return new SuccessResult();
        }

        public IResult Delete(CreateCartItemDto createCartItemDto)
        {
            var cartItem = _cartItemDal.Get(ci=>ci.CartItemId == createCartItemDto.CartItemId);
            _cartItemDal.Delete(cartItem);
            return new SuccessResult();
        }

        public IDataResult<List<CartItem>> GetAll()
        {
            return new SuccessDataResult<List<CartItem>>(_cartItemDal.GetAll());
        }

        public IDataResult<CartItem> GetById(int id)
        {
            return new SuccessDataResult<CartItem>(_cartItemDal.Get(c=>c.CartItemId == id));
        }

        public IResult Update(UpdateCartItemDto updateCartItemDto)
        {
            var cartItem = _cartItemDal.Get(ci=>ci.CartItemId == updateCartItemDto.CartItemId);
            cartItem.Quantity = updateCartItemDto.Quantity;
            _cartItemDal.Update(cartItem);
            return new SuccessResult();
        }
    }
}
