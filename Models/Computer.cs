using System.ComponentModel.DataAnnotations;

namespace csci340lab7.Models;

public class Computer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Manufacturer { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public decimal InitialPrice { get; set; }
    public string? OperatingSystem { get; set; }
    public decimal ProcessorSpeed { get; set; }
    public decimal MemorySize { get; set; }
}