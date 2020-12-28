using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;


namespace HealthCheck
{
    public class ICMPHealthCheck : IHealthCheck
    {
        private string Host = "www.does-not-exist.com";
        private int Timeout = 300;

        public async Task<HealthCheckResult> CheckHealthAsync (
            HealthCheckConext context,
            CancellationToken CancellationToken = default)
            {
                try
                {
                   using (var ping = new Ping ())
                   {
                       var replay = await ping.SendPingAsync(Host);
                       switch (replay.Status)
                       {
                           case IPStatus.Success:
                                return (replay.RoundtripTime > Timeout)
                                        ? HealthCheckResult.Degraded()
                                        : HealthCheckResult.Healthy();
                            default:
                                return HealthCheckResult.Unhealthy();

                       }
                   }
                }
                catch (Exception e)
                {
                    return HealthCheckResult.Unhealthy();
                }
            }
    }

}
