using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Sinks.File;
using Serilog.Sinks.File.Extensions;
using System;
using System.Text;

namespace Serilog
{
    public static class FileExtensions
    {
        public static LoggerConfiguration FileWithTimestamp(this LoggerSinkConfiguration sinkConfiguration,
            string path,
            LogEventLevel restrictedToMinimumLevel = LogEventLevel.Verbose,
            string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
            IFormatProvider? formatProvider = null,
            long? fileSizeLimitBytes = 1073741824,
            LoggingLevelSwitch? levelSwitch = null,
            bool buffered = false,
            bool shared = false,
            TimeSpan? flushToDiskInterval = null,
            RollingInterval rollingInterval = RollingInterval.Infinite,
            bool rollOnFileSizeLimit = false,
            int? retainedFileCountLimit = 31,
            Encoding? encoding = null,
            FileLifecycleHooks? hooks = null,
            TimeSpan? retainedFileTimeLimit = null)
        {
            path = TimestampHelper.ReplaceTimestampTimeSlugs(path, SystemTime.Now());
            return FileLoggerConfigurationExtensions.File(sinkConfiguration, path, restrictedToMinimumLevel, outputTemplate, formatProvider, fileSizeLimitBytes, levelSwitch, buffered, shared, flushToDiskInterval, rollingInterval, rollOnFileSizeLimit, retainedFileCountLimit, encoding, hooks, retainedFileTimeLimit);
        }

        public static LoggerConfiguration FileWithTimestamp(this LoggerSinkConfiguration sinkConfiguration,
            ITextFormatter formatter,
            string path,
            LogEventLevel restrictedToMinimumLevel = LogEventLevel.Verbose,
            long? fileSizeLimitBytes = 1073741824,
            LoggingLevelSwitch? levelSwitch = null,
            bool buffered = false,
            bool shared = false,
            TimeSpan? flushToDiskInterval = null,
            RollingInterval rollingInterval = RollingInterval.Infinite,
            bool rollOnFileSizeLimit = false,
            int? retainedFileCountLimit = 31,
            Encoding? encoding = null,
            FileLifecycleHooks? hooks = null,
            TimeSpan? retainedFileTimeLimit = null)
        {
            path = TimestampHelper.ReplaceTimestampTimeSlugs(path, SystemTime.Now());
            return FileLoggerConfigurationExtensions.File(sinkConfiguration, formatter, path, restrictedToMinimumLevel, fileSizeLimitBytes, levelSwitch, buffered, shared, flushToDiskInterval, rollingInterval, rollOnFileSizeLimit, retainedFileCountLimit, encoding, hooks, retainedFileTimeLimit);
        }

        public static LoggerConfiguration FileWithTimestamp(
            this LoggerAuditSinkConfiguration sinkConfiguration,
            string path,
            LogEventLevel restrictedToMinimumLevel = LogEventLevel.Verbose,
            string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
            IFormatProvider? formatProvider = null,
            LoggingLevelSwitch? levelSwitch = null,
            Encoding? encoding = null,
            FileLifecycleHooks? hooks = null)
        {
            path = TimestampHelper.ReplaceTimestampTimeSlugs(path, SystemTime.Now());
            return FileLoggerConfigurationExtensions.File(sinkConfiguration, path, restrictedToMinimumLevel, outputTemplate, formatProvider, levelSwitch, encoding, hooks);
        }

        public static LoggerConfiguration FileWithTimestamp(
            this LoggerAuditSinkConfiguration sinkConfiguration,
            ITextFormatter formatter,
            string path,
            LogEventLevel restrictedToMinimumLevel = LogEventLevel.Verbose,
            LoggingLevelSwitch? levelSwitch = null,
            Encoding? encoding = null,
            FileLifecycleHooks? hooks = null)
        {
            path = TimestampHelper.ReplaceTimestampTimeSlugs(path, SystemTime.Now());
            return FileLoggerConfigurationExtensions.File(sinkConfiguration, formatter, path, restrictedToMinimumLevel, levelSwitch, encoding, hooks);
        }
    }
}
