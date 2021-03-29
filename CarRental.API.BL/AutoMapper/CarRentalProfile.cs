using AutoMapper;
using CarRental.API.BL.Models;
using CarRental.API.BL.Models.Car;
using CarRental.API.BL.Models.Clients;
using CarRental.API.BL.Models.Prices;
using CarRental.API.BL.Models.RentalLocations;
using CarRental.API.BL.Models.Reservations;
using CarRental.API.DAL.Entities;
using CarRental.API.DAL.CustomEntities;
using System;
using System.Collections.Generic;
using System.Text;
using CarRental.API.BL.Models.CarMaintenance;

namespace CarRental.API.BL.AutoMapper
{
    public class CarRentalProfile : Profile
    {
        public CarRentalProfile()
        {
            CreateMap<CarItem, CarModel>().ReverseMap();
            CreateMap<CarItem, CreateCarModel>().ReverseMap();
            CreateMap<CarItem, CarAvailabilityModel>().ReverseMap();
            CreateMap<ClientsItem, ClientsModel>().ReverseMap();
            CreateMap<ClientsItem, CreateClientModel>().ReverseMap();
            CreateMap<ClientsItem, UpdateClientModel>().ReverseMap();
            CreateMap<PriceItem, PriceModel>().ReverseMap();
            CreateMap<PriceItem, CarPrice>().ReverseMap();
            CreateMap<PriceItem, CreatePriceModel>().ReverseMap();
            CreateMap<ReservationItem, CreateReservationModel>().ReverseMap();
            CreateMap<ReservationItem, CreateReservationWithNewClientModel>().ReverseMap();
            CreateMap<ReservationItem, ReservationModel>().ReverseMap();
            CreateMap<ReservationItem, UpdateReservationModel>().ReverseMap();
            CreateMap<RentalLocationItem, RentalLocationModel>().ReverseMap();
            CreateMap<RentalLocationItem, CreateRentalLocationModel>().ReverseMap();
            CreateMap<DetailedReservations, DetailedReservationModel>().ReverseMap();
            CreateMap<DetailedPrices, DetailedPriceItem>().ReverseMap();
            CreateMap<CarsToBeMaintained, CarMaintenanceModel>().ReverseMap();
            CreateMap<CarServicesModel, CarsServiceHistory>().ReverseMap();
            CreateMap<ServiceItem, CarNewServiceModel>().ReverseMap();
        }
    }
}
