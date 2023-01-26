using Business.Abstract;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.Dtos.ProductDtos;
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

        public IResult Add(CreateProduct createProduct)
        {
            var product = new Product()
            {
                Name = createProduct.Name,
                Stock = createProduct.Stock,
                Description = createProduct.Description,
                Price = createProduct.Price,
                CategoryId = createProduct.CategoryId,
            };

            _productDal.Add(product);
            return new SuccessResult();
        }

        public IResult Delete(CreateProduct createProduct)
        {
            var product = _productDal.Get(p => p.ProductId == createProduct.ProductId);
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

        public IResult Update(CreateProduct createProduct)
        {
            var product = _productDal.Get(p=>p.ProductId== createProduct.ProductId);
            product.Name= createProduct.Name;
            product.Description= createProduct.Description;
            product.Price= createProduct.Price;
            product.Stock= createProduct.Stock;
            product.CategoryId = createProduct.CategoryId;
            _productDal.Update(product);
            return new SuccessResult();
        }
    }
}
