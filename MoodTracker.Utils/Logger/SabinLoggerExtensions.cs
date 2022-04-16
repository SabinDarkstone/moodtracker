using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace MoodTracker.Utils.Logger {
    public static class SabinLoggerExtensions {

        public static ILoggingBuilder AddSabinLogger(this ILoggingBuilder builder) {
            builder.AddConfiguration();

            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, SabinLoggerProvider>());

            LoggerProviderOptions.RegisterProviderOptions
                <SabinLoggerConfiguration, SabinLoggerProvider>(builder.Services);

            return builder;
        }

        public static ILoggingBuilder AddSabinLogger(this ILoggingBuilder builder, Action<SabinLoggerConfiguration> configure) {
            builder.AddSabinLogger();
            builder.Services.Configure(configure);

            return builder;
        }
    }
}
