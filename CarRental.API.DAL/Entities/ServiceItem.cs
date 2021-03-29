using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRental.API.DAL.Entities
{
    [Table("ServiceItems")]
    public class ServiceItem
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public DateTime LastServiceDate { get; set; }

        public int LastServiceMileage { get; set; }

        public int ServiceIntervalKm { get; set; }

        public int ServiceIntervalDate { get; set; }
    }
}

