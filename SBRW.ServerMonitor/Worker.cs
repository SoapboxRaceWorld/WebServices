using Flurl;
using Flurl.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SBRW.Data;
using SBRW.Data.Entities;
using SBRW.ServerMonitor.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SBRW.ServerMonitor
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<Worker> _logger;

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Fetching server stats");
                await FetchServerStats();
                await Task.Delay(30000, stoppingToken);
            }
        }

        private async Task FetchServerStats()
        {
            using var scope = _serviceProvider.CreateScope();
            
            var context = scope.ServiceProvider.GetRequiredService<ServiceDbContext>();

            foreach (var server in context.Servers)
            {
                await FetchServerStats(context, server);
            }

            await context.SaveChangesAsync();
        }

        private async Task FetchServerStats(ServiceDbContext context, Server server)
        {
            var stats = new ServerStats {Server = server, TrackedAt = DateTime.Now};

            var infoUrl = new Url(server.GameEndpoint).AppendPathSegment("GetServerInformation");

            try
            {
                var serverInformation = JsonConvert.DeserializeObject<ServerInformation>(
                    await infoUrl.WithHeader("User-Agent", "SBRW-ServerMonitor")
                        .WithHeader("Accept", "application/json").GetStringAsync());
                stats.Status = ServerStatus.Online;
                stats.PlayersOnline = serverInformation.NumOnline;
                stats.PlayersRegistered = serverInformation.NumRegistered;
            }
            catch (Exception e)
            {
                stats.Status = ServerStatus.Offline;
                _logger.LogError(e, "Failed to fetch stats for {Name} @ {Endpoint}", server.Name, infoUrl);
            }

            context.Add(stats);
        }
    }
}
