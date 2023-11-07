using FUCarRentingManagement.Domain.Entities;
using FUCarRentingManagement.Infrastructure;
using FUCarRentingManagement.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FUCarRentingManagement.Api.Repositories
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufactureRepository
    {
        private readonly FucarRentingManagementContext _dbContext;
        
        public ManufacturerRepository(FucarRentingManagementContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckExistenceManufacturerInCar(int manufacturerId)
        {
            return await _dbContext.CarInformations.AnyAsync(car => car.ManufacturerId == manufacturerId);    
        }

        public async Task<Manufacturer> GetManufacturerOfACar(int carId)
        {
            return await _dbContext.Manufacturers
                .Include(manu => manu.CarInformations)
                .Where(manu => manu.CarInformations.Any(car => car.CarId == carId)).FirstOrDefaultAsync();
        }
    }
}
