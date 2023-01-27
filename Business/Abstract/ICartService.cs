using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.CartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartService
    {
        IDataResult<List<Cart>> GetAll();
        IDataResult<List<CartDetailsDto>> GetDetails();
        IDataResult<Cart> GetById(int id);
        IDataResult<List<CartItem>> GetCartItemsByCartId(int id);
        IResult Add(Cart cart);
        IResult Update(Cart cart);
    }
}
