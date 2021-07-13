using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Serilog
{
    public class SerilogInitialize
    {
        private readonly long _fileSizeLimitBytes = 100000000;
        private readonly int _retainedFileCountLimit = 10;

        public SerilogInitialize(LogEventLevel level)
        {
            var levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = level;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File($"logs/Serilog_Log.txt",
                LogEventLevel.Information,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: _retainedFileCountLimit,
                fileSizeLimitBytes: _fileSizeLimitBytes,
                rollOnFileSizeLimit: true)
                 .WriteTo.Console()
                 .MinimumLevel.ControlledBy(levelSwitch)
                 .CreateLogger();
        }

    }
}
