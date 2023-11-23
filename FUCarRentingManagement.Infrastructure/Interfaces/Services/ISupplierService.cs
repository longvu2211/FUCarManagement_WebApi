using FUCarRentingManagement.Domain.Entities;

namespace FUCarRentingManagement.Infrastructure.Interfaces.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetSuppliers();

        Task<Supplier> GetSupplier(int supplierId);

        Task AddSupplier(Supplier supplier);

        Task UpdateSupplier(Supplier supplier);

        Task RemoveSupplier(int supplierId);

        Task<Supplier> GetSupplierOfACar(int carId);
    }
}
