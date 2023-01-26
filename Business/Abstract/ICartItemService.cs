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
        IResult Add(CreateCartItemDto createCartItemDto);
        IResult Update(UpdateCartItemDto updateCartItemDto);
        IResult Delete(CreateCartItemDto createCartItemDto);
        IResult AddToCart(AddToCartDto addToCartDto);
    }
}
