using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductDetailsDto
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }

    }
}
