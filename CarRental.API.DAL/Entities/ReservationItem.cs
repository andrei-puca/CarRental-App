using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRental.API.DAL.Entities
{
    [Table("ReservationItems")]
    public class ReservationItem
    {
        [Key]
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
