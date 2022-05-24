using AutoMapper;
using Beacon.core.Models;
using Beacon.service.DTOs.MessageDtos;
using Beacon.service.DTOs.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.service.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Service, ServiceGetDto>();
            CreateMap<ServicePostDto, Service>();
            CreateMap<ServiceEditDto, Service>();
         
            //CreateMap<Category, CategoryListItemDto>();
        }
    }
}
