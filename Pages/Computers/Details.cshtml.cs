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
    public class DetailsModel : PageModel
    {
        private readonly csci340lab7.Data.RazorPagesComputerContext _context;

        public DetailsModel(csci340lab7.Data.RazorPagesComputerContext context)
        {
            _context = context;
        }

      public Computer Computer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Computer == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer.FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }
            else 
            {
                Computer = computer;
            }
            return Page();
        }
    }
}
