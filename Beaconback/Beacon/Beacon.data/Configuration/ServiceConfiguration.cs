using Beacon.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.data.Configuration
{
    class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Image).IsRequired(true);
            builder.Property(x => x.DescriptionAz).IsRequired(true);
            builder.Property(x => x.DescriptionEn).IsRequired(true);
        }
    }
}
