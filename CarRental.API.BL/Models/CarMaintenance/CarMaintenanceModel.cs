using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.Models.CarMaintenance
{
    public class CarMaintenanceModel
    {
        public Guid CarId { get; set; }

        public string Brand { get; set; }
        
        public string Model { get; set; }
        
        public int MileageUntilService { get; set; }

        public int MonthsUntilService { get; set; }

    }
}
