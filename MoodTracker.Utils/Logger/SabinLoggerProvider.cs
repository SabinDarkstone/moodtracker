using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Utils.Logger {
    
    [UnsupportedOSPlatform("browser")]
    [ProviderAlias("SabinLogger")]
    public sealed class SabinLoggerProvider : ILoggerProvider {

        private readonly IDisposable _onChangeToken;
        private SabinLoggerConfiguration _currentConfig;
        private readonly ConcurrentDictionary<string, SabinLogger> _loggers =
            new(StringComparer.OrdinalIgnoreCase);

        public SabinLoggerProvider(IOptionsMonitor<SabinLoggerConfiguration> config) {
            _currentConfig = config.CurrentValue;
            _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new SabinLogger(name, GetCurrentConfig));

        private SabinLoggerConfiguration GetCurrentConfig() => _currentConfig;

        public void Dispose() {
            _loggers.Clear();
            _onChangeToken.Dispose();
        }
    }
}
