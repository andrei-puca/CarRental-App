using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.Models
{
    public class CarModel
    { 
        public Guid Id { get; set; }
        
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Mileage { get; set; }

        public bool IsAvailable { get; set; }
    }
}
