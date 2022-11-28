using MediatR;
using PagedList;
using Iox.Api.Models;

namespace Iox.Api.Queries;

public class GetVehicleListQuery : IRequest<PagedList<Vehicle>>
{
    public long? VIN { get; }
    public string? LicenseNumber { get; }
    public string? RegistrationPlate { get; }
    public DateTime? LicenseExpiry { get; }
    public string? Model { get; }
    public string? Color { get; }
    public long? Account { get; }
    public int PageNo { get; } = 0;
    public int PageSize { get; } = 0;

    public GetVehicleListQuery(
        long? vin,
        string? licenseNumber,
        string? registrationPlate,
        DateTime? licenseExpiry,
        string? model,
        string? color,
        long? account,
        int pageNo,
        int pageSize)
    {
        VIN = vin;
        LicenseNumber = licenseNumber;
        RegistrationPlate = registrationPlate;
        LicenseExpiry = licenseExpiry;
        Model = model;
        Color = color;
        Account = account;
        PageNo = pageNo;
        PageSize = pageSize;
    }
}