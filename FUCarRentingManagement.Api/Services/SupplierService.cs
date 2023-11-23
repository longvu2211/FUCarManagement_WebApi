using FUCarRentingManagement.Domain.Entities;
using FUCarRentingManagement.Infrastructure.Exceptions;
using FUCarRentingManagement.Infrastructure.Interfaces.Repositories;
using FUCarRentingManagement.Infrastructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace FUCarRentingManagement.Api.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task AddSupplier(Supplier supplier)
        {
            try
            {
                if (supplier == null) throw new BusinessException("Supplier is empty!");
                await _supplierRepository.Add(supplier);
                await _supplierRepository.Save();
            } catch (BusinessException ex)
            {
                throw new BusinessException("An error occurs while adding supplier!", ex);
            }
        }

        public async Task<Supplier> GetSupplier(int supplierId)
        {
            return await _supplierRepository.GetById(supplierId);
        }

        public async Task<Supplier> GetSupplierOfACar(int carId)
        {
            return await _supplierRepository.GetSupplierOfACar(carId);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _supplierRepository.GetAll()
                .OrderBy(sup => sup.SupplierId)
                .ToListAsync();
        }

        public async Task RemoveSupplier(int supplierId)
        {
            try
            {
                var supplier = await _supplierRepository.GetById(supplierId);
                if (supplier == null) throw new BusinessException("Supplier is empty!");
                _supplierRepository.Remove(supplier);
                await _supplierRepository.Save();
            } catch (BusinessException ex)
            {
                throw new Exception("An error occurs while removing supplier!", ex);
            }
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
            try
            {
                var existingSupplier = await _supplierRepository.GetById(supplier.SupplierId);
                if (existingSupplier == null) throw new BusinessException("Supplier is empty!");

                existingSupplier.SupplierName = supplier.SupplierName;
                existingSupplier.SupplierDescription = supplier.SupplierDescription;
                existingSupplier.SupplierAddress = supplier.SupplierAddress;

                _supplierRepository.Update(existingSupplier);
                await _supplierRepository.Save();
            } catch (BusinessException ex)
            {
                throw new Exception("An error occurs while updating supplier!", ex);
            }
        }
    }
}
