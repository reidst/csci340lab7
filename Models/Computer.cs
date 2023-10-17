using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csci340lab7.Models;

public class Computer
{
    public int Id { get; set; }
    [StringLength(60, MinimumLength = 2)]
    [Required]
    public string? Name { get; set; }
    [StringLength(60, MinimumLength = 2)]
    [Required]
    public string? Manufacturer { get; set; }
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    [Display(Name = "Initial Price (USD)")]

    [Column(TypeName = "decimal(18, 2)")]
    [DataType(DataType.Currency)]
    public decimal InitialPrice { get; set; }
    [Display(Name = "Operating System")]
    [StringLength(120)]
    [Required]
    public string? OperatingSystem { get; set; }
    [Display(Name = "Processor Speed (MHz)")]
    public decimal ProcessorSpeed { get; set; }
    [Display(Name = "Memory Size (KB)")]
    public int MemorySize { get; set; }
}