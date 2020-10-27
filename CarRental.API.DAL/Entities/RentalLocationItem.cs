using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRental.API.DAL.Entities
{
    [Table("RentalLocation")]

    public class RentalLocationItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

    }
}
