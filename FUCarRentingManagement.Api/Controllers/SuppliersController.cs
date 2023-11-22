using Microsoft.AspNetCore.Mvc;
using FUCarRentingManagement.Infrastructure.Interfaces.Services;
using AutoMapper;
using System.Net;
using FUCarRentingManagement.Api.Dtos;

namespace FUCarRentingManagement.Api.Controllers
{
    public class SuppliersController : BaseApiController
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }
        
        [HttpGet("suppliers")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliers()
        {
            var suppliers = await _supplierService.GetSuppliers();
            if (!suppliers.Any()) return NotFound("Supplier is not found!");
            var mappedSuppliers = _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
            return Ok(mappedSuppliers);
        }

        // GET: api/Suppliers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Supplier>> GetSupplier(int id)
        //{
        //  if (_context.Suppliers == null)
        //  {
        //      return NotFound();
        //  }
        //    var supplier = await _context.Suppliers.FindAsync(id);

        //    if (supplier == null)
        //    {
        //        return NotFound();
        //    }

        //    return supplier;
        //}

        // PUT: api/Suppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSupplier(int id, Supplier supplier)
        //{
        //    if (id != supplier.SupplierId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(supplier).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SupplierExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        //{
        //  if (_context.Suppliers == null)
        //  {
        //      return Problem("Entity set 'FucarRentingManagementContext.Suppliers'  is null.");
        //  }
        //    _context.Suppliers.Add(supplier);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSupplier", new { id = supplier.SupplierId }, supplier);
        //}

        // DELETE: api/Suppliers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSupplier(int id)
        //{
        //    if (_context.Suppliers == null)
        //    {
        //        return NotFound();
        //    }
        //    var supplier = await _context.Suppliers.FindAsync(id);
        //    if (supplier == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Suppliers.Remove(supplier);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
