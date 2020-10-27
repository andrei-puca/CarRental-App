using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.Models.Prices
{
    public class PriceModel
    {
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public int Price { get; set; }
    }
}
