using Microsoft.Extensions.Logging;

namespace WeChat.Framework.Tests
{
    public class NullLoggerFactory : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {

        }

        public ILogger CreateLogger(string categoryName)
        {
            return NullLogger.Instance;
        }

        public void Dispose()
        {
        }
    }
}
