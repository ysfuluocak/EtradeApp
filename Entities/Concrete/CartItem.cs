using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CartItem : IEntity
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public virtual  Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
