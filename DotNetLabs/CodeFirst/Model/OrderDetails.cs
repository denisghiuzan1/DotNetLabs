using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst1.Model
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
