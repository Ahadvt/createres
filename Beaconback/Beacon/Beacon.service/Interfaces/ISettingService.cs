using Beacon.service.DTOs.SettingDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beacon.service.Services
{
    public interface ISettingService
    {
        SettingGetDto GetSetting();
        Task UpdateAsync(int id ,SettingPostDto postDto);
    }
}
