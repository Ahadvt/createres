using AutoMapper;
using Beacon.core;
using Beacon.core.Models;
using Beacon.service.DTOs;
using Beacon.service.DTOs.ServiceDtos;
using Beacon.service.Exeptions;
using Beacon.service.Extentions;
using Beacon.service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beacon.service.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public ServiceService(IUnitOfWork unitOfWork, IWebHostEnvironment env,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _mapper = mapper;
        }
        public async Task CreateAsync(ServicePostDto postDto)
        {
            Service service = _mapper.Map<Service>(postDto);

            service.Image = postDto.Image.SaveImage(_env.WebRootPath, "images");

            await _unitOfWork.ServiceRepository.AddAsync(service);

            await _unitOfWork.CommitAsync();
        }

        public async Task<ServiceGetDto> Get(int id)
        {
            Service service = await _unitOfWork.ServiceRepository.GetAsync(x => x.Id == id);

            if (service == null)
                throw new ItemNotFoundExeption("Item is not found");

            ServiceGetDto serviceGet = _mapper.Map<ServiceGetDto>(service);
            return serviceGet;
        }

        public async Task<GetListDto<ServiceGetDto>> GetAll()
        {
            var query = _unitOfWork.ServiceRepository.GetAll();

            GetListDto<ServiceGetDto> getListDto = new GetListDto<ServiceGetDto>();
            getListDto.Items = query.Select(x => new ServiceGetDto { Image = x.Image, DescriptionAz = x.DescriptionAz, DescriptionEn = x.DescriptionEn,Id=x.Id }).ToList();
            return getListDto;
        }

        public async Task RemoveAync(int id)
        {
            Service service = await _unitOfWork.ServiceRepository.GetAsync(x => x.Id == id);

            if (service == null)
                throw new ItemNotFoundExeption("Item is not found");

            await _unitOfWork.ServiceRepository.Remove(service);
            await _unitOfWork.CommitAsync();

        }

        public async Task UpdateAsync(int id, ServiceEditDto dto)
        {
            Service service = await _unitOfWork.ServiceRepository.GetAsync(x => x.Id == id);
            if (service == null)
                throw new ItemNotFoundExeption("Item is not found");

            service.DescriptionAz = dto.DescriptionAz;
            service.DescriptionEn = dto.DescriptionEn;

            if (dto.Image != null)
            {
                Helpers.Helper.DeleteImage(_env.WebRootPath, "images", service.Image);
                service.Image = dto.Image.SaveImage(_env.WebRootPath, "images");
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
