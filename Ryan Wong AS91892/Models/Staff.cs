using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ryan_Wong_AS91892.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Wages { get; set; }
        public DateTime HireDate { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}
