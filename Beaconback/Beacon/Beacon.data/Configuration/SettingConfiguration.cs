using Beacon.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.data.Configuration
{
    class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(x => x.Logo).IsRequired(true);
            builder.Property(x => x.InfoIMage).IsRequired(true);
            builder.Property(x => x.PhoneNumber).IsRequired(true);
            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.SiteName).IsRequired();
            builder.Property(x => x.AboutCompanyAz).IsRequired(true);
            builder.Property(x => x.AboutCompanyEn).IsRequired(true);
        }
    }
}
