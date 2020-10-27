using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.Models.RentalLocations
{
    public class CreateRentalLocationModel
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }
    }
}
