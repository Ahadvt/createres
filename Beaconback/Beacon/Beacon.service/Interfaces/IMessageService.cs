using Beacon.service.DTOs;
using Beacon.service.DTOs.MessageDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beacon.service.Interfaces
{
   public interface IMessageService
    {
        Task Create(MessagePostDto postDto);
        Task<GetListDto<MessageGetDto>> GetALl();
        Task<MessageGetDto> Get(int id);
        Task Remove(int id);

    }
}
