using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csci340lab7.Data;
using csci340lab7.Models;

namespace csci340lab7.Pages_Computers
{
    public class EditModel : PageModel
    {
        private readonly csci340lab7.Data.RazorPagesComputerContext _context;

        public EditModel(csci340lab7.Data.RazorPagesComputerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Computer Computer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Computer == null)
            {
                return NotFound();
            }

            var computer =  await _context.Computer.FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }
            Computer = computer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Computer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(Computer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ComputerExists(int id)
        {
          return (_context.Computer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
