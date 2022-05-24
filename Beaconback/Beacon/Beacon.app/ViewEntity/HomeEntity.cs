using Beacon.service.DTOs.MessageDtos;
using Beacon.service.DTOs.SettingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beacon.app.ViewEntity
{
    public class HomeEntity
    {
        public SettingGetDto SettingGetDto { get; set; }
        public MessagePostDto MessagePostDto { get; set; }
    }
}
