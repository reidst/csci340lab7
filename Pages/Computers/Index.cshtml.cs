using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340lab7.Data;
using csci340lab7.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Manufacturers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ComputerManufacturer { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of manufacturers.
            IQueryable<string> manufacturerQuery = from c in _context.Computer
                                                     orderby c.Manufacturer
                                                     select c.Manufacturer;
            
            var computers = from c in _context.Computer
                        select c;

            if (!string.IsNullOrEmpty(SearchString))
            {
                computers = computers.Where(
                    s => s.OperatingSystem.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ComputerManufacturer))
            {
                computers = computers.Where(
                    x => x.Manufacturer == ComputerManufacturer);
            }

            Manufacturers = new SelectList(
                await manufacturerQuery.Distinct().ToListAsync());
            Computer = await computers.ToListAsync();
        }
    }
}
