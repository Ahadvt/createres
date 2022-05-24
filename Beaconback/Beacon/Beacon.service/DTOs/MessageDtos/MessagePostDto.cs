using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.service.DTOs.MessageDtos
{
  public  class MessagePostDto
    {
        public string Text { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
    }
    public class MessagePostValidator : AbstractValidator<MessagePostDto>
    {
        public MessagePostValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Text).NotEmpty().MaximumLength(100);
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(20);
        }
    }
}
