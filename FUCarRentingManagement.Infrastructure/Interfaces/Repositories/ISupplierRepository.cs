using FUCarRentingManagement.Domain.Entities;

namespace FUCarRentingManagement.Infrastructure.Interfaces.Repositories
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Task<Supplier> GetSupplierOfACar(int carId);
    }
}
