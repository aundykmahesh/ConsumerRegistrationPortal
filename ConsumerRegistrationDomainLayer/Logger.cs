using System;
using NLog;

namespace ConsumerRegistrationPortal.DomainLayer
{
    public class Logger : Interfaces.IILogger
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public LogLevel ConvertLogLevel(LoggingEventType type)
        {
            switch (type)
            {
                case LoggingEventType.info:
                    return LogLevel.Info;
                case LoggingEventType.warn:
                    return LogLevel.Warn;
                case LoggingEventType.error:
                    return LogLevel.Error;
                case LoggingEventType.fatal:
                    return LogLevel.Fatal;
                default:
                    return LogLevel.Info;
            }
        }

        public void Log(string message, LoggingEventType type)
        {
            _logger.Log(ConvertLogLevel(type), message);
        }

        public void Log(Exception message, LoggingEventType type)
        {
            _logger.Log(ConvertLogLevel(type), message);
        }
    }
}