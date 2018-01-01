using Hangfire;
using HostedService.Data;
using HostedService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostedService.Services
{
    public  class InsertEngine
    {
        ApplicationDbContext _context;
        IRand _rand;
        private readonly ILogger<InsertEngine> _logger;
        public InsertEngine(ApplicationDbContext context, IRand rand, ILogger<InsertEngine> logger)
        {
            _context = context;
            _rand = rand;
            _logger = logger;
        }
        public  void Start(IJobCancellationToken cancellationToken)
        {
            _logger.LogCritical($"InsertEngine is starting.");

            _context.Persons.Add(new Person() {
                Name = _rand.GetRandomString()
            });
            _context.SaveChangesAsync();
            
        }       
    }
}
