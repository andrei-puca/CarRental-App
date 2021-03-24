﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.DAL.CustomEntities
{
    public class CarsServiceHistory
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime LastServiceDate { get; set; }
    }
}
