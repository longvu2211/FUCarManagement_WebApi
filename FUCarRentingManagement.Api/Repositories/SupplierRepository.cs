using FUCarRentingManagement.Domain.Entities;
using FUCarRentingManagement.Infrastructure;
using FUCarRentingManagement.Infrastructure.Interfaces.Repositories;

namespace FUCarRentingManagement.Api.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private readonly FucarRentingManagementContext _dbContext;

        public SupplierRepository(FucarRentingManagementContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
