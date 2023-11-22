﻿using FUCarRentingManagement.Domain.Entities;

namespace FUCarRentingManagement.Api.Dtos
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; } = null!;

        public string? SupplierDescription { get; set; }

        public string? SupplierAddress { get; set; }
        
        public virtual ICollection<CarInformation> CarInformations { get; set; } = new List<CarInformation>();  // will be changed; testing purpose
    }
}
