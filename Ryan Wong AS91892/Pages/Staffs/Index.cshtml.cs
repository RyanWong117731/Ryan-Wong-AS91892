using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ryan_Wong_AS91892.Data;
using Ryan_Wong_AS91892.Models;

namespace Ryan_Wong_AS91892.Pages.Staffs
{
    public class IndexModel : PageModel
    {
        private readonly Ryan_Wong_AS91892.Data.ItemShopContext _context;

        public IndexModel(Ryan_Wong_AS91892.Data.ItemShopContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string WagesSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Staff> Staff { get; set; }

        public async Task OnGetAsync(string sortOrder,
         string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            WagesSort = sortOrder == "Wages" ? "wages_desc" : "Wages";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Staff> studentsIQ = from s in _context.Staffs
                                           select s;

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.FirstName);
                    break;
                case "Wages":
                    studentsIQ = studentsIQ.OrderBy(s => s.Wages);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.FirstName);
                    break;
            }

            int pageSize = 3;
            Staff = await PaginatedList<Staff>.CreateAsync(
                studentsIQ
                .AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
