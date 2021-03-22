using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.Models.Prices
{
    public class DetailedPrices
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Price { get; set; }

    }
}
