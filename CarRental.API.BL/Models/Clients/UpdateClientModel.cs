using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.Models.Clients
{
    public class UpdateClientModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
