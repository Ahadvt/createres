using Beacon.core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beacon.core
{
    public interface IUnitOfWork
    {
        ISettingRepository SettingRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IMessageRepository MessageRepository { get; }

        int Commit();

        Task<int> CommitAsync();

    }
}
