using AutoMapper;
using CarRental.API.BL.Models;
using CarRental.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.BL.AutoMapper
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoItem, TodoModel>().ReverseMap();
        }
    }
}
