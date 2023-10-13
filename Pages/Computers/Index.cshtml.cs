using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340lab7.Data;
using csci340lab7.Models;

namespace csci340lab7.Pages_Computers
{
    public class IndexModel : PageModel
    {
        private readonly csci340lab7.Data.RazorPagesComputerContext _context;

        public IndexModel(csci340lab7.Data.RazorPagesComputerContext context)
        {
            _context = context;
        }

        public IList<Computer> Computer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Computer != null)
            {
                Computer = await _context.Computer.ToListAsync();
            }
        }
    }
}
