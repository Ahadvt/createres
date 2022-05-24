using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.core.Models
{
  public  class Message:Base
    {
        public string Text { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }

    }
}
