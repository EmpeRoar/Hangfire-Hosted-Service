using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SENTINEL.Services
{
    public class DataRefresh : BackgroundService
    {
        private readonly ILogger<DataRefresh> _logger;
            
        public DataRefresh( ILogger<DataRefresh> logger)
        {
            _logger = logger;            
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _logger.LogCritical($"DataRefreshService is starting.");

            stoppingToken.Register(() => _logger.LogCritical($" DataRefreshService background task is stopping."));

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogCritical($" Count {i}");                
                i++;

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);

            }

            _logger.LogCritical($"DataRefreshService background task is stopping.");
        }
    }
}
