namespace Iox.Api.Models;

public class Vehicle
{
    public long? VIN { get; set; }
    public string? LicenseNumber { get; set; } = string.Empty;
    public string? RegistrationPlate { get; set; } = string.Empty;
    public DateTime LicenseExpiry { get; set; }
    public string? Model { get; set; } = string.Empty;
    public string? Color { get; set; } = string.Empty;
    public long? AccountForeignKey { get; set; }
    public Account? Account { get; set; }
    
}