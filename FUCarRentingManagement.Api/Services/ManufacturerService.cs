using FUCarRentingManagement.Domain.Entities;
using FUCarRentingManagement.Infrastructure.Exceptions;
using FUCarRentingManagement.Infrastructure.Interfaces.Repositories;
using FUCarRentingManagement.Infrastructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace FUCarRentingManagement.Api.Services
{
    /// <summary>
    /// Can be used Singleton Pattern, but not recommended
    /// </summary>
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufactureRepository _manufactureRepository;

        public ManufacturerService(IManufactureRepository manufactureRepository)
        {
            _manufactureRepository = manufactureRepository;
        }
        public async Task AddManufacturer(Manufacturer manufacturer)
        {
            try
            {
                // check duplication of manufacturer
                await _manufactureRepository.Add(manufacturer);
                await _manufactureRepository.Save();
            } catch (BusinessException ex)
            {
                throw new BusinessException("An error occurs while adding the manufacturer!", ex);
            }
        }

        public async Task<Manufacturer> GetManufacturer(int manufacturerId)
        {
            try
            {
                return await _manufactureRepository.GetById(manufacturerId);    

            } catch(BusinessException ex)
            {
                throw new BusinessException("Something went wrong!", ex);   
            }
        }

        public async Task<Manufacturer> GetManufacturerOfACar(int carId)
        {
            try
            {
                return await _manufactureRepository.GetManufacturerOfACar(carId);   

            } catch(BusinessException ex)
            {
                throw new BusinessException("Something went wrong!", ex);
            }
        }

        public async Task<IEnumerable<Manufacturer>> GetManufacturers()
        {
            try
            {
                return await _manufactureRepository.GetAll()
                    .OrderBy(m => m.ManufacturerId)
                    .ToListAsync();
            } catch(BusinessException ex)
            {
                throw new BusinessException("Something went wrong!", ex);
            }
        }

        public async Task RemoveManufacturer(int manufacturerId)
        {
            try
            {
                var manufacturer = await _manufactureRepository.GetById(manufacturerId);
                if (manufacturer != null)
                {
                    var checkResult = await _manufactureRepository.CheckExistenceManufacturerInCar(manufacturerId);
                    if (checkResult) throw new BusinessException("Cannot remove this manufacturer because it is being used in car!");
                    _manufactureRepository.Remove(manufacturer);
                    await _manufactureRepository.Save();
                }
            } catch (BusinessException ex)
            {
                throw new BusinessException("An error occurs while removing the manufacturer!", ex);
            }
        }

        public async Task UpdateManufacturer(Manufacturer manufacturer)
        {
            try
            {
                var existedManufacturer = await _manufactureRepository.GetById(manufacturer.ManufacturerId);
                if (manufacturer == null) throw new BusinessException("Manufacturer is not found!");

                existedManufacturer.ManufacturerName = manufacturer.ManufacturerName;
                existedManufacturer.ManufacturerCountry = manufacturer.ManufacturerCountry;
                existedManufacturer.Description = manufacturer.Description;

                _manufactureRepository.Update(existedManufacturer);
                await _manufactureRepository.Save();
            } catch (BusinessException ex)
            {
                throw new Exception("An error occurs while updating the manufacturer!", ex);
            }
        }
    }
}
