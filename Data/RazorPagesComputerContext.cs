using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using csci340lab7.Models;

namespace csci340lab7.Data
{
    public class RazorPagesComputerContext : DbContext
    {
        public RazorPagesComputerContext (DbContextOptions<RazorPagesComputerContext> options)
            : base(options)
        {
        }

        public DbSet<csci340lab7.Models.Computer> Computer { get; set; } = default!;
    }
}
