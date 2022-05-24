using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.service.DTOs
{
   public class GetListDto<TItem>
    {
        public List<TItem> Items { get; set; }
    }
}
