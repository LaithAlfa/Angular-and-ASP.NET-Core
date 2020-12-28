using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;

namespace HealthCheck
{
    public class CustomHealthCheckOption : HealthCheckOptions
    {
        public CustomHealthCheckOption() : base()
        {
            var jsonSerialiserOption = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            ResponseWriter = async (c, r) =>
            {
                c.Response.ContentType = MediaTypeNames.Application.Json;
                c.Response.StatusCode = StatusCodes.Status200OK;

                var result = JsonSerializer.Serialize(new 
                {
                    checks = r.Entries.Select(e => new
                    {
                            name = e.Key,
                            response =
                            e.Value.Duration.TotalMilliseconds, 
                            status = e.Value.Status.ToString(),
                            description = e.Value.Description
                    }),
                    totalStatus = r.Status,
                    totalResponseTime = 
                        r.TotalDuration.TotalMilliseconds,
                },
                jsonSerialiserOption);
                
               await c.Response.WriteAsync(result);
            };
        }
    }
}
