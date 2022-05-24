using Beacon.service.DTOs;
using Beacon.service.DTOs.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beacon.service.Interfaces
{
   public interface IServiceService
    {
         Task CreateAsync(ServicePostDto postDto);
         Task UpdateAsync(int id, ServiceEditDto dto);
         Task RemoveAync(int id);
         Task<ServiceGetDto> Get(int id);
         Task<GetListDto<ServiceGetDto>> GetAll();

    }
}
