using HostedService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostedService.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext DbContext { get; }
        int Save();
    }
}
