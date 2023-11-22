using Microsoft.AspNetCore.Mvc;
using FUCarRentingManagement.Domain.Entities;
using System.Net;
using FUCarRentingManagement.Api.Dtos;
using FUCarRentingManagement.Infrastructure.Interfaces.Services;
using AutoMapper;
using FUCarRentingManagement.Infrastructure.Exceptions;

namespace FUCarRentingManagement.Api.Controllers
{
    public class ManufacturersController : BaseApiController
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IMapper _mapper;

        public ManufacturersController(IManufacturerService manufacturerService, IMapper mapper)
        {
            _manufacturerService = manufacturerService;
            _mapper = mapper;
        }

        [HttpGet("manufacturers")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ManufacturerDto>>> GetManufacturers()
        {
            var manufacturers = await _manufacturerService.GetManufacturers();
            if (manufacturers is null) return NotFound("Manufacturer is not found!");
            var mappedManufacturers = _mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers)
                .Select(x => new ManufacturerDto
                {
                    ManufacturerId = x.ManufacturerId,
                    ManufacturerName = x.ManufacturerName,
                    ManufacturerCountry = x.ManufacturerCountry,
                    Description = x.Description,
                });
            return Ok(mappedManufacturers);
        }

        [HttpGet("manufacturers/{manufacturerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Manufacturer>> GetManufacturer(int manufacturerId)
        {
            var manufacturer = await _manufacturerService.GetManufacturer(manufacturerId);
            if (manufacturer == null)
                return NotFound("Manufacturer is not found!");
            var mappedManufacturer = _mapper.Map<ManufacturerDto>(manufacturer);
            return Ok(mappedManufacturer);
        }

        [HttpGet("cars/{carId}/manufacturer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ManufacturerDto>> GetManufacturerOfACar(int carId)
        {
            var manufacturer = await _manufacturerService.GetManufacturerOfACar(carId);
            if (manufacturer == null)
                return NotFound("Manufacturer is not found!");
            var mappedManufacturer = _mapper.Map<ManufacturerDto>(manufacturer);
            return Ok(mappedManufacturer);
        }

        [HttpPut("manufacturer/{manufacturerId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> UpdateManufacturer(int manufacturerId, ManufacturerDto manufacturerDto)
        {
            try
            {
                if (manufacturerId != manufacturerDto.ManufacturerId)
                    return Conflict(new ProblemDetails
                    {
                        Title = "Manufacturer id does not match!"
                    });

                if (string.IsNullOrEmpty(manufacturerDto.ManufacturerName))
                    return ValidationProblem(new ValidationProblemDetails
                    {
                        Title = "Manufacturer name is required!"
                    });

                if (string.IsNullOrEmpty(manufacturerDto.ManufacturerCountry))
                    return ValidationProblem(new ValidationProblemDetails
                    {
                        Title = "Manufacturer country is required!"
                    });

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                await _manufacturerService.UpdateManufacturer(_mapper.Map<Manufacturer>(manufacturerDto));
                return NoContent();
            } catch(BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("manufacturer")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<ManufacturerDto>> CreateManufacturer(ManufacturerDto manufacturerDto)
        {
            try
            {
                if (string.IsNullOrEmpty(manufacturerDto.ManufacturerName))
                    return ValidationProblem(new ValidationProblemDetails
                    {
                        Title = "Manufacturer name is required!"
                    });

                if (string.IsNullOrEmpty(manufacturerDto.ManufacturerCountry))
                    return ValidationProblem(new ValidationProblemDetails
                    {
                        Title = "Manufacturer country is required!"
                    });
            
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState);
            
                var manufacturer = _mapper.Map<Manufacturer>(manufacturerDto);
                await _manufacturerService.AddManufacturer(manufacturer);

                var createdManu = _mapper.Map<ManufacturerDto>(manufacturer);
                return CreatedAtAction(nameof(GetManufacturer), new { manufacturerId = createdManu.ManufacturerId }, createdManu);
            } catch(BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("manufacturer/{manufacturerId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteManufacturer(int manufacturerId)
        {
            try
            {
                if (manufacturerId <= 0)
                    return ValidationProblem(new ValidationProblemDetails
                    {
                        Title = "Manufacturer id is required!"
                    });
                await _manufacturerService.RemoveManufacturer(manufacturerId);
                return NoContent();

            } catch(BusinessException ex)
            {
                return BadRequest(ex.Message);
            } 
        }
    }
}
