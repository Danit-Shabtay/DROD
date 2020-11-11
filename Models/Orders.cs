using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DROD.Models
{
    public class Orders
    {
        public int ID { get; set; }

        public int OrderId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }
    }
}
