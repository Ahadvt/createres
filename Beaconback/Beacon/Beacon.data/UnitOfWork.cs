using Beacon.core;
using Beacon.core.Repositories;
using Beacon.data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beacon.data
{
    public class UnitOfWork : IUnitOfWork
    {
        ISettingRepository _settingRepository;
        IServiceRepository _serviceRepository;
        IMessageRepository _messageRepository;

        private readonly BeaconDbContext _context;
        public UnitOfWork(BeaconDbContext context)
        {
            _context = context;
        }
        public ISettingRepository SettingRepository => _settingRepository ?? new SettingRepository(_context);

        public IServiceRepository ServiceRepository => _serviceRepository ?? new ServiceRepository(_context);

        public IMessageRepository MessageRepository => _messageRepository??new MessageRepository(_context);

        public int Commit()
        {
           return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
