using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ProductDtos
{
    public class CreateProduct : IDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
