using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ryan_Wong_AS91892.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ItemType { get; set; }
        public float Price { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}
