using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
