using Beacon.core;
using Beacon.core.Models;
using Beacon.service.DTOs.SettingDtos;
using Beacon.service.Exeptions;
using Beacon.service.Extentions;
using Beacon.service.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beacon.service.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public SettingService(IUnitOfWork unitOfWork, IWebHostEnvironment env )
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }
        public SettingGetDto GetSetting()
        {
            Setting setting =  _unitOfWork.SettingRepository.GetSetting();

            SettingGetDto getDto = new SettingGetDto
            {
                Logo=setting.Logo,
                InfoIMage=setting.InfoIMage,
                AboutCompanyAz=setting.AboutCompanyAz,
                AboutCompanyEn=setting.AboutCompanyEn,
                Email=setting.Email,
                PhoneNumber=setting.PhoneNumber,
                SiteName=setting.SiteName,
                Id=setting.Id
                
            };

            return getDto;
        }

        public async Task UpdateAsync(int id, SettingPostDto postDto)
        {
            Setting setting = await _unitOfWork.SettingRepository.GetAsync(x => x.Id == id);

            if (setting == null)
                throw new ItemNotFoundExeption("Item is not found");

            setting.SiteName = postDto.SiteName;
            setting.PhoneNumber  = postDto.PhoneNumber;
            setting.Email  = postDto.Email;
            setting.AboutCompanyAz  = postDto.AboutCompanyAz;
            setting.AboutCompanyEn  = postDto.AboutCompanyEn;

            if (postDto.Logo!=null)
            {
                Helpers.Helper.DeleteImage(_env.WebRootPath, "Images", setting.Logo);
                setting.Logo = postDto.Logo.SaveImage(_env.WebRootPath,"images");
            }

            if (postDto.InfoImage != null)
            {
                Helpers.Helper.DeleteImage(_env.WebRootPath, "Images", setting.InfoIMage);
                setting.InfoIMage = postDto.InfoImage.SaveImage(_env.WebRootPath, "images");
            }



            await _unitOfWork.CommitAsync();
        }
    }
}
