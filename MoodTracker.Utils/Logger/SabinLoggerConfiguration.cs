using Microsoft.Extensions.Logging;

namespace MoodTracker.Utils.Logger {
    public class SabinLoggerConfiguration {
        public int EventId { get; set; }

        public Dictionary<LogLevel, ConsoleColor> LogLevels { get; set; } = new() {
            [LogLevel.Information] = ConsoleColor.Green,
            [LogLevel.Warning] = ConsoleColor.Yellow,
            [LogLevel.Error] = ConsoleColor.Red,
        };
    }
}
