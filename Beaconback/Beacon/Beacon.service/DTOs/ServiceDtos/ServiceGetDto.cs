using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.service.DTOs.ServiceDtos
{
   public class ServiceGetDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string DescriptionAz { get; set; }
        public string DescriptionEn { get; set; }
    }
}
