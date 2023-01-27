using Business.Abstract;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.Dtos.CartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public IResult Add(Cart cart)
        {
            _cartDal.Add(cart);
            return new SuccessResult();
        }

        public IDataResult<List<Cart>> GetAll()
        {
            return new SuccessDataResult<List<Cart>>(_cartDal.GetAll());
        }

        public IDataResult<Cart> GetById(int id)
        {
            return new SuccessDataResult<Cart>(_cartDal.Get(c => c.CartId == id));
        }

        public IDataResult<List<CartItem>> GetCartItemsByCartId(int id)
        {
            return new SuccessDataResult<List<CartItem>>(_cartDal.GetCartItemsByCartId(id));
        }

        public IDataResult<List<CartDetailsDto>> GetDetails()
        {
            return new SuccessDataResult<List<CartDetailsDto>>(_cartDal.GetDetailsDto());
        }

        public IResult Update(Cart cart)
        {
            _cartDal.Update(cart);
            return new SuccessResult();
        }
    }
}
