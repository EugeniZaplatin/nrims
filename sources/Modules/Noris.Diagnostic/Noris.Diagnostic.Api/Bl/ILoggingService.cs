namespace Noris.Diagnostic.Services.API
{
    using System;

    public interface ILoggingService
    {
        void Trace<T>(object message);
        void Trace<T>(object message, Exception exception);
        void TraceFormat<T>(string format, params object[] args);
        void TraceFormat<T>(string format, Exception exception, params object[] args);

        void Debug<T>(object message);
        void Debug<T>(object message, Exception exception);
        void DebugFormat<T>(string format, params object[] args);
        void DebugFormat<T>(string format, Exception exception, params object[] args);

        void Info<T>(object message);
        void Info<T>(object message, Exception exception);
        void InfoFormat<T>(string format, params object[] args);
        void InfoFormat<T>(string format, Exception exception, params object[] args);

        void Warn<T>(object message);
        void Warn<T>(object message, Exception exception);
        void WarnFormat<T>(string format, params object[] args);
        void WarnFormat<T>(string format, Exception exception, params object[] args);

        void Error<T>(object message);
        void Error<T>(object message, Exception exception);
        void ErrorFormat<T>(string format, params object[] args);
        void ErrorFormat<T>(string format, Exception exception, params object[] args);

        void Fatal<T>(object message);
        void Fatal<T>(object message, Exception exception);
        void FatalFormat<T>(string format, params object[] args);
        void FatalFormat<T>(string format, Exception exception, params object[] args);
    }
}
