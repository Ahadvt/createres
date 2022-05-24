using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.service.DTOs.MessageDtos
{
   public class MessageGetDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
    }
}
