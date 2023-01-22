using Core.DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfPoductDal : EfEntityRepositoryBase<Product,EtradeContext>,IProductDal
    {
    }
}
