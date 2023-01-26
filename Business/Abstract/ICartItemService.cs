using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.CartItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartItemService
    {
        IDataResult<List<CartItem>> GetAll();
        IDataResult<CartItem> GetById(int id);
        IResult Update(UpdateCartItemDto updateCartItemDto);
        IResult Delete(UpdateCartItemDto updateCartItemDto);
        IResult AddToCart(AddToCartDto addToCartDto);
    }
}
