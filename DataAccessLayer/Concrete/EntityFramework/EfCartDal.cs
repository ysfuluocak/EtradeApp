using Core.DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using Entities.Concrete;
using Entities.Dtos.CartDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, EtradeContext>, ICartDal
    {
        public List<CartDetailsDto> GetDetailsDto()
        {
            using (var context = new EtradeContext())
            {
                var result = from c in context.Carts
                             join ci in context.CartItems
                             on c.CartId equals ci.CartId
                             select new CartDetailsDto { CartId = c.CartId, ProductName = ci.Product.Name, CategoryName = ci.Product.Category.Name, CreatedAt = c.CreatedAt,CartItemPrice = ci.Price, TotalPrice = c.TotalPrice };
                return result.ToList();
            }
        }
    }
}
