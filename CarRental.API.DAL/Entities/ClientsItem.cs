﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace CarRental.API.DAL.Entities
{
    [Table("Clients")]
    public class ClientsItem
    {
        [Key]
        public Guid Id { get; set; }

        public string FullName { get; set; }

    }
}
