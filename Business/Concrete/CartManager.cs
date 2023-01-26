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

        public IDataResult<List<Cart>> GetAll()
        {
            return new SuccessDataResult<List<Cart>>(_cartDal.GetAll());
        }

        public IDataResult<Cart> GetById(int id)
        {
            return new SuccessDataResult<Cart>(_cartDal.Get(c => c.CartId == id));
        }
    }
}
