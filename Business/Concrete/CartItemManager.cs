using Business.Abstract;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.Dtos.CartDtos;
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
        ICartService _cartService;
        IProductService _productService;
        public CartItemManager(ICartItemDal cartItemDal, ICartService cartService, IProductService productService)
        {
            _cartItemDal = cartItemDal;
            _cartService = cartService;
            _productService = productService;
        }

        public IResult AddToCart(AddToCartDto addToCartDto)
        {
            if (addToCartDto.CartId == 0)
            {
                var product = _productService.GetById(addToCartDto.ProductId);
                var cartItem = new CartItem()
                {
                    ProductId = addToCartDto.ProductId,
                    Quantity = addToCartDto.Quantity,
                    Price = product.Data.Price*addToCartDto.Quantity,
                    Cart = new Cart()
                    {
                        CreatedAt = DateTime.Now,
                        TotalPrice = addToCartDto.Quantity * product.Data.Price
                    }
                };
                _cartItemDal.Add(cartItem);
            }
            else
            {
                var cart = _cartService.GetById(addToCartDto.CartId);
                var product = _productService.GetById(addToCartDto.ProductId);
                cart.Data.CartItems = new HashSet<CartItem>() {
                    new CartItem()
                    {
                        ProductId = addToCartDto.ProductId,
                        Quantity = addToCartDto.Quantity,
                        Price = product.Data.Price*addToCartDto.Quantity
                    }};
                cart.Data.TotalPrice += addToCartDto.Quantity * product.Data.Price;
                _cartService.Update(cart.Data);
            }
            return new SuccessResult();
        }

        public IResult Delete(UpdateCartItemDto updateCartItemDto)
        {
            var cartItem = _cartItemDal.Get(ci => ci.CartItemId == updateCartItemDto.CartItemId);
            _cartItemDal.Delete(cartItem);
            return new SuccessResult();
        }

        public IDataResult<List<CartItem>> GetAll()
        {
            return new SuccessDataResult<List<CartItem>>(_cartItemDal.GetAll());
        }

        public IDataResult<CartItem> GetById(int id)
        {
            return new SuccessDataResult<CartItem>(_cartItemDal.Get(c => c.CartItemId == id));
        }

        public IResult Update(UpdateCartItemDto updateCartItemDto)
        {
            var cartItem = _cartItemDal.Get(ci => ci.CartItemId == updateCartItemDto.CartItemId);
            cartItem.Quantity = updateCartItemDto.Quantity;
            _cartItemDal.Update(cartItem);
            return new SuccessResult();
        }
    }
}
