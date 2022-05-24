using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.service.DTOs.ServiceDtos
{
    public class ServiceEditDto
    {
        public IFormFile Image { get; set; }
        public string DescriptionAz { get; set; }
        public string DescriptionEn { get; set; }
        public ServiceGetDto GetDto { get; set; }
    }

    public class ServiceEditValidator : AbstractValidator<ServiceEditDto>
    {

        public ServiceEditValidator()
        {
            RuleFor(x => x.DescriptionEn).NotEmpty().WithMessage("Xidmet Acixlamasi bos ola bilmez");
            RuleFor(x => x.DescriptionAz).NotEmpty().WithMessage("Xidmet Acixlamasi bos ola bilmez");
        }
    }
}
