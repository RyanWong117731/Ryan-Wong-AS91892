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
    public class DetailsModel : PageModel
    {
        private readonly Ryan_Wong_AS91892.Data.ItemShopContext _context;

        public DetailsModel(Ryan_Wong_AS91892.Data.ItemShopContext context)
        {
            _context = context;
        }

        public Staff Staff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff = await _context.Staffs.FirstOrDefaultAsync(m => m.StaffID == id);

            if (Staff == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
