using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ZonyLrcTools.Common.Infrastructure.DependencyInject;
using ZonyLrcTools.Common.Infrastructure.Logging;

namespace ZonyLrcTools.Desktop.Infrastructure.Logging;

public class SerilogWarpLogger(ILogger<SerilogWarpLogger> logger) : IWarpLogger, ITransientDependency
{
    public Task DebugAsync(string message, Exception? exception = null)
    {
        logger.LogDebug(message, exception);

        return Task.CompletedTask;
    }

    public Task InfoAsync(string message, Exception? exception = null)
    {
        logger.LogInformation(message, exception);
        return Task.CompletedTask;
    }

    public Task WarnAsync(string message, Exception? exception = null)
    {
        logger.LogWarning(message, exception);
        return Task.CompletedTask;
    }

    public Task ErrorAsync(string message, Exception? exception = null)
    {
        logger.LogError(message, exception);
        return Task.CompletedTask;
    }
}