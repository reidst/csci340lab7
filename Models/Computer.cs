using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csci340lab7.Models;

public class Computer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Manufacturer { get; set; }
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    [Display(Name = "Initial Price (USD)")]

    [Column(TypeName = "decimal(18, 2)")]
    public decimal InitialPrice { get; set; }
    [Display(Name = "Operating System")]
    public string? OperatingSystem { get; set; }
    [Display(Name = "Processor Speed (MHz)")]
    public decimal ProcessorSpeed { get; set; }
    [Display(Name = "Memory Size (KB)")]
    public int MemorySize { get; set; }
}