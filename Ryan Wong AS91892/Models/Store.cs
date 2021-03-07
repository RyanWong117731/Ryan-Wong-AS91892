using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ryan_Wong_AS91892.Models
{
    public class Store
    {
        public int StoreID { get; set; }
        public int ItemID { get; set; }
        public int StaffID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Item Items { get; set; }
        public Staff Staffs { get; set; }
    }
}
