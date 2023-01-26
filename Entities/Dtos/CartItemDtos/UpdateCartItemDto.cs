using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.CartItemDtos
{
    public class UpdateCartItemDto : IDto
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
