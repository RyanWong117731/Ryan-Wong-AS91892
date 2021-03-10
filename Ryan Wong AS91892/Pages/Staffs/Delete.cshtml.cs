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
    public class DeleteModel : PageModel
    {
        private readonly Ryan_Wong_AS91892.Data.ItemShopContext _context;

        public DeleteModel(Ryan_Wong_AS91892.Data.ItemShopContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff = await _context.Staffs.FindAsync(id);

            if (Staff != null)
            {
                _context.Staffs.Remove(Staff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
