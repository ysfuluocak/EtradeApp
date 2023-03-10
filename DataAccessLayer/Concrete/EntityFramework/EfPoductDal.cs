using Core.DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using Entities.Concrete;
using Entities.Dtos.ProductDtos;
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
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailsDto { ProductId = p.ProductId, CategoryName = c.Name, Price = p.Price, Name=p.Name,Description = p.Description,Stock = p.Stock};
                return result.ToList();
            }
        }
    }
}
