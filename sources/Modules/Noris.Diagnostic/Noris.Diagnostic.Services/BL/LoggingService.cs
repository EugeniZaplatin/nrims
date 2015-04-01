namespace Noris.Diagnostic.Services.BL
{
    using System;
    
    using Common.Logging;

    using Microsoft.Practices.Unity;

    using Noris.Unity.Attributes;
    using Noris.Diagnostic.Services.API;

    [Service(forInterface: typeof(ILoggingService))]
    public class LoggingService : ILoggingService
    {
        [Dependency]
        public INotificationService NotificationService { get; set; }

        private ILog GetLogger<T>()
        {
            return LogManager.GetLogger<T>();
        }
        
        public void Trace<T>(object message)
        {
            GetLogger<T>().Trace(message);
        }

        public void Trace<T>(object message, Exception exception)
        {
            GetLogger<T>().Trace(message, exception);
        }

        public void TraceFormat<T>(string format, params object[] args)
        {
            GetLogger<T>().TraceFormat(format, args);
        }

        public void TraceFormat<T>(string format, Exception exception, params object[] args)
        {
            GetLogger<T>().TraceFormat(format, exception, args);
        }

        public void Debug<T>(object message)
        {
            GetLogger<T>().Debug(message);
        }

        public void Debug<T>(object message, Exception exception)
        {
            GetLogger<T>().Debug(message, exception);
        }

        public void DebugFormat<T>(string format, params object[] args)
        {
            GetLogger<T>().DebugFormat(format, args);
        }

        public void DebugFormat<T>(string format, Exception exception, params object[] args)
        {
            GetLogger<T>().DebugFormat(format, exception, args);
        }

        public void Info<T>(object message)
        {
            GetLogger<T>().Info(message);
        }

        public void Info<T>(object message, Exception exception)
        {
            GetLogger<T>().Info(message, exception);
        }

        public void InfoFormat<T>(string format, params object[] args)
        {
            GetLogger<T>().InfoFormat(format, args);
        }

        public void InfoFormat<T>(string format, Exception exception, params object[] args)
        {
            GetLogger<T>().InfoFormat(format, exception, args);
        }

        public void Warn<T>(object message)
        {
            GetLogger<T>().Warn(message);
        }

        public void Warn<T>(object message, Exception exception)
        {
            GetLogger<T>().Warn(message, exception);
        }

        public void WarnFormat<T>(string format, params object[] args)
        {
            GetLogger<T>().WarnFormat(format, args);
        }

        public void WarnFormat<T>(string format, Exception exception, params object[] args)
        {
            GetLogger<T>().WarnFormat(format, exception, args);
        }

        public void Error<T>(object message)
        {
            GetLogger<T>().Error(message);
        }

        public void Error<T>(object message, Exception exception)
        {
            GetLogger<T>().Error(message, exception);
        }

        public void ErrorFormat<T>(string format, params object[] args)
        {
            GetLogger<T>().ErrorFormat(format, args);
        }

        public void ErrorFormat<T>(string format, Exception exception, params object[] args)
        {
            GetLogger<T>().ErrorFormat(format, exception, args);
        }

        public void Fatal<T>(object message)
        {
            GetLogger<T>().Fatal(message);
        }

        public void Fatal<T>(object message, Exception exception)
        {
            GetLogger<T>().Fatal(message, exception);
        }

        public void FatalFormat<T>(string format, params object[] args)
        {
            GetLogger<T>().FatalFormat(format, args);
        }

        public void FatalFormat<T>(string format, Exception exception, params object[] args)
        {
            GetLogger<T>().FatalFormat(format, exception, args);
        }
    }
}