using AutoMapper;
using CarRental.API.BL.Models;
using CarRental.API.BL.Models.Clients;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.AutoMapper
{
    public class CarRentalProfile : Profile
    {
        public CarRentalProfile()
        {
            CreateMap<CarItem, CarModel>().ReverseMap();
            CreateMap<ClientsItem, ClientsModel>().ReverseMap();
        }
    }
}
