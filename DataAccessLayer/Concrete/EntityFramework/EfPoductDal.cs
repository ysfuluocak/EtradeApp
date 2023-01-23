using Core.DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfPoductDal : EfEntityRepositoryBase<Product, EtradeContext>, IProductDal
    {
        public List<ProductDetailsDto> GetProductDetailsDtos()
        {
            using (var context = new EtradeContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductDetailsDto { ProductId = p.Id, CategoryName = c.Name, Price = p.Price };
                return result.ToList();
            }
        }
    }
}
