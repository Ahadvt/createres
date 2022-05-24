using Beacon.core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beacon.core.Repositories
{
   public interface ISettingRepository:IRepository<Setting>
    {
        Setting GetSetting();
    }
}
