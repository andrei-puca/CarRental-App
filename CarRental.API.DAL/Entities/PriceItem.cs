using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRental.API.DAL.Entities
{
    [Table("PriceModels")]
    public class PriceItem
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid CarId { get; set; }

        public int Price { get; set; }

    }
}
