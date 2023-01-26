using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}
