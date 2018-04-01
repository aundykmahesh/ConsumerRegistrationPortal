
using System;

namespace ConsumerRegistrationPortal.DomainLayer.Interfaces
{
    public interface IILogger
    {
        void Log(string message, LoggingEventType type);
        void Log(Exception message, LoggingEventType type);
        NLog.LogLevel ConvertLogLevel(LoggingEventType type);
    }
}
