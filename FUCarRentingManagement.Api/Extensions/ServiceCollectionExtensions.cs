using FUCarRentingManagement.Api.Repositories;
using FUCarRentingManagement.Api.Services;
using FUCarRentingManagement.Infrastructure.Interfaces.Repositories;
using FUCarRentingManagement.Infrastructure.Interfaces.Services;

namespace FUCarRentingManagement.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IManufactureRepository), typeof(ManufacturerRepository));
            services.AddScoped<IManufacturerService, ManufacturerService>();
        }
    }
}
