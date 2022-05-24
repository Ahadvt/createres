using Beacon.core.Models;
using Beacon.core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.data.Repositories
{
  public  class MessageRepository:Repository<Message>,IMessageRepository
    {
        public MessageRepository(BeaconDbContext context):base(context)
        {

        }
    }
}
