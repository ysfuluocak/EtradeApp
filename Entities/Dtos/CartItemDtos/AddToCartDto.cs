using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.CartItemDtos
{
    public class AddToCartDto : IDto
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
    }
}
