using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ryan_Wong_AS91892.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        
        [Required]
        [Column("Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("Description")]
        public string Description { get; set; }
        [Required]
        [Column("Itemtype")]
        [StringLength(50)]
        public string ItemType { get; set; }
        [Required]
        [Column("Price")]
        public float Price { get; set; }

        public ICollection<ItemAssignment> ItemAssignment { get; set; }
    }
}
