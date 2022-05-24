using AutoMapper;
using Beacon.core;
using Beacon.core.Models;
using Beacon.service.DTOs;
using Beacon.service.DTOs.MessageDtos;
using Beacon.service.Exeptions;
using Beacon.service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beacon.service.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Create(MessagePostDto postDto)
        {
            Message message = new Message();
            message = _mapper.Map<Message>(postDto);
           await _unitOfWork.MessageRepository.AddAsync(message);
            await _unitOfWork.CommitAsync();
        }

        public async Task<MessageGetDto> Get(int id)
        {
            Message message = await _unitOfWork.MessageRepository.GetAsync(x => x.Id == id);

            if(message==null)
                throw new ItemNotFoundExeption("Item is not found");

            MessageGetDto GetDto = _mapper.Map<MessageGetDto>(message);
            return GetDto;
        }

        public async Task<GetListDto<MessageGetDto>> GetALl()
        {
            var query =  _unitOfWork.MessageRepository.GetAll();

            GetListDto<MessageGetDto> getListDto = new GetListDto<MessageGetDto>();
            getListDto.Items = query.Select(x => new MessageGetDto { FullName = x.FullName, Email = x.Email, Text = x.Text, PhoneNumber=x.PhoneNumber,Id=x.Id}).ToList();
            return getListDto;
        }

        public async Task Remove(int id)
        {
            Message message = await _unitOfWork.MessageRepository.GetAsync(x => x.Id == id);

            if (message == null)
                throw new ItemNotFoundExeption("Item Not Found");

            await _unitOfWork.MessageRepository.Remove(message);

            await _unitOfWork.CommitAsync();
        }
    }
}
