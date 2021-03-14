using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ryan_Wong_AS91892.Data;
using Ryan_Wong_AS91892.Models;

namespace Ryan_Wong_AS91892.Pages.Stores
{
    public class IndexModel : PageModel
    {
        private readonly Ryan_Wong_AS91892.Data.ItemShopContext _context;

        public IndexModel(Ryan_Wong_AS91892.Data.ItemShopContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string LocationSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Store> Store { get; set; }

        public async Task OnGetAsync(string sortOrder,
         string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            LocationSort = String.IsNullOrEmpty(sortOrder) ? "location_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Store> studentsIQ = from s in _context.Stores
                                           select s;

            switch (sortOrder)
            {
                
                case "location_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.Location);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.Location);
                    break;
            }

            int pageSize = 3;
            Store = await PaginatedList<Store>.CreateAsync(
                studentsIQ
                .Include(s => s.StaffAssignments)
                    .ThenInclude(m => m.Staff)
                .Include(a => a.ItemAssignments)
                    .ThenInclude(b => b.Item)
                .AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
