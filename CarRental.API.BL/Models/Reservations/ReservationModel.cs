using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.Models.Reservations
{
    public class ReservationModel
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid CarId { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public Guid PickUpLocation { get; set; }

        public Guid DropOffLocation { get; set; }

        public int TotalPrice { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

    }
}
