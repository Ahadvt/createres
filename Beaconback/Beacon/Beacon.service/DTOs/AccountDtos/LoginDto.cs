using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.service.DTOs.AccountDtos
{
   public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username or password in correct");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Username or password in correct");
        }
    }
}
