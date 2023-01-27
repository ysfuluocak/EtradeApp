using Core.DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.Dtos.CartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICartDal : IEntityRepositoryBase<Cart>
    {
        List<CartDetailsDto> GetDetailsDto();
        List<CartItem> GetCartItemsByCartId(int id);
    }
}
