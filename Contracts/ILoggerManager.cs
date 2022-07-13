namespace Contracts
{
    public interface ILoggerManager<T>
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}