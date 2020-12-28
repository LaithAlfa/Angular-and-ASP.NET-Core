using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;


namespace HealthCheck
{
    public class ICMPHealthCheck : IHealthCheck
    {

        private string Host {get; set;}
        private int Timeout {get; set;}

        public ICMPHealthCheck(string host, int timeout)
        {
            Host = host;
            Timeout = timeout;
        }

        public async Task<HealthCheckResult> CheckHealthAsync (
            HealthCheckContext context,
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
                            string msg = String.Format(
                               "ICMP to {0} took {1} ms.", Host, replay.RoundtripTime);
                           
                                return (replay.RoundtripTime > Timeout)
                                        ? HealthCheckResult.Degraded(msg)
                                        : HealthCheckResult.Healthy(msg);
                            default:
                            string err = String.Format("IMCP to {0} failed: {1}", Host, replay.Status);
                                return HealthCheckResult.Unhealthy(err);

                       }
                   }
                }
                catch (Exception e)
                    {
                         string err = String.Format(
                             "IMCP to {0} failed: {1}",
                                Host, 
                                e.Message);
                    return HealthCheckResult.Unhealthy();
                    }
            }
        }

    }

