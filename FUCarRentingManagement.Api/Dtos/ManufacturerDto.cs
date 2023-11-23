using FUCarRentingManagement.Domain.Entities;

namespace FUCarRentingManagement.Api.Dtos
{
    public class ManufacturerDto
    {
        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; } = null!;

        public string? Description { get; set; }

        public string? ManufacturerCountry { get; set; }
    }
}
