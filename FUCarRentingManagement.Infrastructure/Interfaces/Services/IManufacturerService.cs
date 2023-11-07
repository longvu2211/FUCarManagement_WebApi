using FUCarRentingManagement.Domain.Entities;

namespace FUCarRentingManagement.Infrastructure.Interfaces.Services
{
    public interface IManufacturerService
    {
        Task<IEnumerable<Manufacturer>> GetManufacturers();

        Task<Manufacturer> GetManufacturer(int manufacturerId);

        Task AddManufacturer(Manufacturer manufacturer);

        Task RemoveManufacturer(int manufacturerId);

        Task UpdateManufacturer(Manufacturer manufacturer);

        Task<Manufacturer> GetManufacturerOfACar(int carId);
    }
}
