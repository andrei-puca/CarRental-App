using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CarRental.API.DAL.Entities
{
    public class CarItem
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Brand { get; set; }

        public string Model { get; set; }
    }
}
