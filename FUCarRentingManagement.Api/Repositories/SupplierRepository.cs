using FUCarRentingManagement.Domain.Entities;
using FUCarRentingManagement.Infrastructure;
using FUCarRentingManagement.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FUCarRentingManagement.Api.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private readonly FucarRentingManagementContext _dbContext;

        public SupplierRepository(FucarRentingManagementContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Supplier> GetSupplierOfACar(int carId)
        {
            //return await _dbContext.Suppliers
            //    .Include(s => s.CarInformations)
            //    .FirstOrDefaultAsync(s => s.CarInformations.Any(c => c.CarId == carId));

            return await _dbContext.CarInformations
                .Include(c => c.Supplier)
                .Where(c => c.CarId == carId)
                .Select(c => c.Supplier).FirstOrDefaultAsync();
        }
    }
}
