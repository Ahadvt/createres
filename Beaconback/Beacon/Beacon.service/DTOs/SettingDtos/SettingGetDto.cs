using Beacon.core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.service.DTOs.SettingDtos
{
    public class SettingGetDto
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string InfoIMage { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string SiteName { get; set; }
        public string AboutCompanyEn { get; set; }
        public string AboutCompanyAz { get; set; }
    }
}
