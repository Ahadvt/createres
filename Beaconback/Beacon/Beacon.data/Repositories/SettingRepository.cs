using Beacon.core.Models;
using Beacon.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beacon.data.Repositories
{
  public  class SettingRepository:Repository<Setting>,ISettingRepository
    {
        private readonly BeaconDbContext _context;

        public SettingRepository(BeaconDbContext context):base(context)
        {
            _context = context;
        }

        public  Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }
    }
}
