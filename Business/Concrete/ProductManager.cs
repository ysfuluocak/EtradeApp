using Business.Abstract;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        public IDataResult<List<ProductDetailsDto>> GetDetails()
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetailsDtos());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult();
        }
    }
}
