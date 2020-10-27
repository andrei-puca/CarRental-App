using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.Models.Reservations
{
    public class CreateReservationWithNewClientModel
    {

        public Guid CarId { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public Guid PickUpLocation { get; set; }

        public Guid DropOffLocation { get; set; }

    }
}
