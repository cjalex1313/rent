using System.ComponentModel.DataAnnotations;
using Rent.API.Models.Base;

namespace Rent.API.Models.Property;

public abstract class AddPropertyRequest : BaseRequest
{
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public string Country { get; set; } = "";
    [Required]
    public string City { get; set; } = "";
    public string? State { get; set; }
    [Required]
    public string Street { get; set; } = "";
    [Required]
    public string PostalCode { get; set; } = "";
    [Required]
    public string Number { get; set; } = "";
    [Required]
    public double Size { get; set; }
}