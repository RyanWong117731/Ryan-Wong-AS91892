using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ryan_Wong_AS91892.Models
{
    public class ItemAssignment
    {
        public int ItemAssignmentID { get; set; }

        public int ItemID { get; set; }
        public int StoreID { get; set; }

        public Item Item { get; set; }
        public Store Store { get; set; }

        
    }
}
