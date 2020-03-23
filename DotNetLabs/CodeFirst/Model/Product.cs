using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst1.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
