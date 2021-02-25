using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ryan_Wong_AS91892.Data;
using Ryan_Wong_AS91892.Models;

namespace Ryan_Wong_AS91892.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly ItemShopContext _context;
        public IndexModel(ItemShopContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Item> Items { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            PriceSort = sortOrder == "Price" ? "Price_desc" : "Price";
            IQueryable<Item> studentsIQ = from s in _context.Items
                                             select s;

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    studentsIQ = studentsIQ.OrderBy(s => s.Price);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.ItemID);
                    break;
            }

            Items = await studentsIQ.AsNoTracking().ToListAsync();
        }
    }
}
