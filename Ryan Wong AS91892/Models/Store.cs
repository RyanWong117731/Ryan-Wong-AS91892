using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ryan_Wong_AS91892.Models
{
    public class Store
    {
        public int StoreID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<StaffAssignment> StaffAssignments { get; set; }
        public ICollection<ItemAssignment> ItemAssignments { get; set; }
    }
}
