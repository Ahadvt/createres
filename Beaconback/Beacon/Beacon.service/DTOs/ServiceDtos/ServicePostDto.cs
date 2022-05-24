
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.service.DTOs.ServiceDtos
{
   public class ServicePostDto
    {
        public IFormFile Image { get; set; }
        public string DescriptionAz { get; set; }
        public string DescriptionEn { get; set; }

    }

    public class ServicePostValidator : AbstractValidator<ServicePostDto>
    {
        public ServicePostValidator()
        {
            RuleFor(x => x.DescriptionEn).NotEmpty().WithMessage("Xidmet Acixlamasi bos ola bilmez");
            RuleFor(x => x.DescriptionAz).NotEmpty().WithMessage("Xidmet Acixlamasi bos ola bilmez");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Servis sekli bos ola bilmez");
        }
    }
}
