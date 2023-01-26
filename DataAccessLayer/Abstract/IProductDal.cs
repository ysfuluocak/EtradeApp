using Core.DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IEntityRepositoryBase<Product>
    {
        List<ProductDetailsDto> GetProductDetailsDtos();
    }
}
