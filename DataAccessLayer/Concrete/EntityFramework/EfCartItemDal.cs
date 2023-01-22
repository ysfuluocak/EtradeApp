using Core.DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCartItemDal : EfEntityRepositoryBase<CartItem,EtradeContext>,ICartItemDal
    {
    }
}
