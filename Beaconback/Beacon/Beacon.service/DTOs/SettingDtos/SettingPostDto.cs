using Beacon.service.Extentions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.service.DTOs.SettingDtos
{
   public class SettingPostDto
    {
        public IFormFile Logo { get; set; }
        public IFormFile InfoImage { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string SiteName { get; set; }
        public string AboutCompanyEn { get; set; }
        public string AboutCompanyAz { get; set; }
        public SettingGetDto GetDto { get; set; }
    }

    public class SettingValidator : AbstractValidator<SettingPostDto>
    {
        public SettingValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Elaqe nomresi bos ola bilmez").MaximumLength(13).WithMessage("Duzgun telefon nomresi daxil edin");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email  bos ola bilmez").EmailAddress().WithMessage("Duzgun Email  daxil edin");
            RuleFor(x => x.SiteName).NotEmpty().WithMessage("SiteName  bos ola bilmez").MaximumLength(30).WithMessage("Maximum uzunluq  30 ola biler");
            RuleFor(x => x.AboutCompanyAz).NotEmpty().WithMessage("SirketHaqqinda  bos ola bilmez");
            RuleFor(x => x.AboutCompanyEn).NotEmpty().WithMessage("SirketHaqqinda  bos ola bilmez");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Logo!=null)
                {
                    if (!x.Logo.IsImage())
                        context.AddFailure("Logo", "Zehmet olmasa image file daxil edin");

                    if (!x.Logo.IsSizeOk())
                        context.AddFailure("Logo", "Image olcusu maximum 2mb ola biler");
                }

                if (x.InfoImage != null)
                {
                    if (!x.InfoImage.IsImage())
                        context.AddFailure("InfoImage", "Zehmet olmasa image file daxil edin");

                    if (!x.InfoImage.IsSizeOk())
                        context.AddFailure("InfoImage", "Image olcusu maximum 2mb ola biler");
                }
            });

        }
    }
}
