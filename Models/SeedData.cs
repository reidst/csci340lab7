using Microsoft.EntityFrameworkCore;
using csci340lab7.Data;

namespace csci340lab7.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new RazorPagesComputerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesComputerContext>>());
        if (context == null || context.Computer == null)
        {
            throw new ArgumentNullException("Null RazorPagesComputerContext");
        }

        // Look for any computers.
        if (context.Computer.Any())
        {
            return;   // DB has been seeded
        }

        context.Computer.AddRange(
            new Computer
            {
                Name = "Apple ][",
                Manufacturer = "Apple Computer, Inc.",
                ReleaseDate = DateTime.Parse("1977-6-1"),
                InitialPrice = 6270.00M,
                OperatingSystem = "Integer BASIC / Apple DOS",
                ProcessorSpeed = 1.023M,
                MemorySize = 64M
            },

            new Computer
            {
                Name = "Commodore 64",
                Manufacturer = "Commodore Business Machines",
                ReleaseDate = DateTime.Parse("1982-8-1"),
                InitialPrice = 1800.00M,
                OperatingSystem = "Commodore KERNAL / BASIC 2.0",
                ProcessorSpeed = 1.023M,
                MemorySize = 64M
            },

            new Computer
            {
                Name = "TRS-80",
                Manufacturer = "Tandy Corporation",
                ReleaseDate = DateTime.Parse("1977-8-3"),
                InitialPrice = 2900.00M,
                OperatingSystem = "TRSDOS / LDOS / NewDos/80 / Level I BASIC",
                ProcessorSpeed = 1.774M,
                MemorySize = 48M
            },

            new Computer
            {
                Name = "BBC Micro (Model A)",
                Manufacturer = "Acorn Computers",
                ReleaseDate = DateTime.Parse("1981-12-1"),
                InitialPrice = 1269.00M,
                OperatingSystem = "Acorn MOS",
                ProcessorSpeed = 2M,
                MemorySize = 32M
            },

            new Computer
            {
                Name = "ZX Spectrum",
                Manufacturer = "Sinclair Research",
                ReleaseDate = DateTime.Parse("1982-4-23"),
                InitialPrice = 870.00M,
                OperatingSystem = "Sinclair BASIC",
                ProcessorSpeed = 3.5M,
                MemorySize = 48M
            }
        );
        context.SaveChanges();
    }
}