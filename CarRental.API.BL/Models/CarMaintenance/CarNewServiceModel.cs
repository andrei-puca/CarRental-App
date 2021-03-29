using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.Models.CarMaintenance
{
    public class CarNewServiceModel
    {
        public Guid CarId { get; set; }

        public DateTime LastServiceDate { get; set; }

        public int LastServiceMileage { get; set; }

        public int ServiceIntervalKm { get; set; }

        public int ServiceIntervalDate { get; set; }
    }
}
