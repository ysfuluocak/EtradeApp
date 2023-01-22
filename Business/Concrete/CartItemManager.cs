using Business.Abstract;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
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
        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        public IResult Add(CartItem cartItem)
        {
             _cartItemDal.Add(cartItem);
            return new SuccessResult();
        }

        public IResult Delete(CartItem cartItem)
        {
            _cartItemDal.Delete(cartItem);
            return new SuccessResult();
        }

        public IDataResult<List<CartItem>> GetAll()
        {
            return new SuccessDataResult<List<CartItem>>(_cartItemDal.GetAll());
        }

        public IDataResult<CartItem> GetById(int id)
        {
            return new SuccessDataResult<CartItem>(_cartItemDal.Get(c=>c.Id == id));
        }

        public IResult Update(CartItem cartItem)
        {
            _cartItemDal.Update(cartItem);
            return new SuccessResult();
        }
    }
}
