using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.Models.Reservations
{
    public class DetailedReservationModel
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public string PickUpLocation { get; set; }

        public string DropOffLocation { get; set; }

        public int TotalPrice { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
