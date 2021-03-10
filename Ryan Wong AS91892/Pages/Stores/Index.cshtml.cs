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

        public IList<Store> Store { get; set; }

        public async Task OnGetAsync()
        {
            Store = await _context.Stores.ToListAsync();
        }
    }
}
