using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Dayana.Shared.Basic.MethodsAndObjects.HealthChecks;

public class GeneralHealthCheck : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = new())
    {
        return HealthCheckResult.Healthy("Everything is Ok!");
    }
}