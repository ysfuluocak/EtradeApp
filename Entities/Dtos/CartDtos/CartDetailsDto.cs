using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.CartDtos
{
    public class CartDetailsDto : IDto
    {
        public int CartId { get; set; }
        public string? ProductName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CategoryName { get; set; }
        public decimal CartItemPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
