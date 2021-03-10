using System;
using System.Collections.Generic;
using System.Linq;
using Ryan_Wong_AS91892.Models;
using System.Threading.Tasks;

namespace Ryan_Wong_AS91892.Models
{
    public class StaffAssignment
    {
        public int StaffAssignmentID { get; set; }
        public int StaffID { get; set; }
        public int StoreID { get; set; }


        public Staff Staff { get; set; }
        public Store Store { get; set; }
    }
}
