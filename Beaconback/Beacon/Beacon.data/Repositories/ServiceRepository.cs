using Beacon.core.Models;
using Beacon.core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.data.Repositories
{
   public class ServiceRepository:Repository<Service>,IServiceRepository
    {
        public ServiceRepository(BeaconDbContext context):base(context)
        {

        }
    }
}
