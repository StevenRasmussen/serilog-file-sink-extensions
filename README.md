[![NuGet version (Serilog.Sinks.File.Extensions)](https://img.shields.io/nuget/v/Serilog.Sinks.File.Extensions.svg)](https://www.nuget.org/packages/Serilog.Sinks.File.Extensions/)
[Version History](#version-history)

# serilog-file-sink-extensions
Adds some useful extensions to the Serilog.File sink.

**Note:** Versioning follows the [major.minor] of Serilog.Sinks.File so that it is easy to know which version to install. 
Ie, if you are using Serilog.Sinks.File v5.x then you would install v5.x of this package. 
Build and revision numbers are not guaranteed to follow the same numbers.

## Create a log file that contains a date in it

To create a logger that is able to 

The syntax for the data slug is the same as that for the logging template, ie `{Timestamp:XXX}`.

Any C# date format strings are accepted. Documentation [here](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings).

```csharp
using Serilog;

void SetupLogger()
{
    var logger = new LoggerConfiguration()
        .WriteTo.FileWithTimestamp("Log File With Date - {Timestamp:yyyy-MM-dd} and Time {Timestamp:h.mm.ss.fff}.log")
        .CreateLogger();

    // A log file is created similar to: "Log File With Date - 2022-01-02 Time 3.04.05.007.log"
}
```



## Version History
* 5.0.0 - Initial Release
