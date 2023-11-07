using FUCarRentingManagement.Domain.Entities;

namespace FUCarRentingManagement.Infrastructure.Interfaces.Repositories
{
    public interface IManufactureRepository : IGenericRepository<Manufacturer>
    {
        Task<bool> CheckExistenceManufacturerInCar(int manufacturerId);
        Task<Manufacturer> GetManufacturerOfACar(int carId);
    }
}
