using AutoMapper;
using Beacon.core.Models;
using Beacon.service.DTOs.MessageDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.service.Profiles
{
   public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<MessagePostDto, Message>();
            CreateMap<Message, MessageGetDto>();
        }
    }
}
