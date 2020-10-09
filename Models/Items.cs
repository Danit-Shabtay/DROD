using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DROD.Models
{
    public enum ItemType
    {
        Men,
        Women,
        Shoes
    }

    public class Items
    {
        public int ID { get; set; }
        public String ItemName { get; set; }
        public double Price { get; set; }
        public ItemType Gender { get; set; }
        public String Path { get; set; }
    }
}
