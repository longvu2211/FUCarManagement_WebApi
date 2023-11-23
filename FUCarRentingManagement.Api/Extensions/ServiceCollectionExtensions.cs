using FUCarRentingManagement.Api.Repositories;
using FUCarRentingManagement.Api.Services;
using FUCarRentingManagement.Infrastructure.Interfaces.Repositories;
using FUCarRentingManagement.Infrastructure.Interfaces.Services;

namespace FUCarRentingManagement.Api.Extensions
{
    /// <summary>
    /// Add your extensions here
    /// Service and Repository interfaces and implementations are registered here
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IManufactureRepository), typeof(ManufacturerRepository));
            services.AddScoped<IManufacturerService, ManufacturerService>();

            services.AddScoped(typeof(ISupplierRepository), typeof(SupplierRepository));
            services.AddScoped<ISupplierService, SupplierService>();
        }
    }
}
