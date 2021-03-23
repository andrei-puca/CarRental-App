using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.API.DAL.Entities
{
    [Table("CarItems")]
    public class CarItem
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int Mileage { get; set; }

        public bool IsAvailable { get; set; }

        
    }
}
