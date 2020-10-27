using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.Models.Prices
{
    public class CreatePriceModel
    {
        public Guid CarId { get; set; }

        public int Price { get; set; }

    }
}
