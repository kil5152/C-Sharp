using log4net;
using System;

namespace WorkerClasses
{
    internal class Logger
    {
        private readonly ILog log4NetAdapter;

        public Logger(Type type)
        {
            this.log4NetAdapter = LogManager.GetLogger(type);
        }

        public void LogDebug(string message)
        {
            this.log4NetAdapter.Debug(message);
        }

        public void LogDebug(string message, Exception exception)
        {
            this.log4NetAdapter.Debug(message, exception);
        }

        public void LogError(string message)
        {
            this.log4NetAdapter.Error(message);
        }

        public void LogError(string message, Exception exception)
        {
            this.log4NetAdapter.Error(message, exception);
        }

        public void LogFatal(string message)
        {
            this.log4NetAdapter.Fatal(message);
        }

        public void LogFatal(string message, Exception exception)
        {
            this.log4NetAdapter.Fatal(message, exception);
        }

        public void LogInfo(string message)
        {
            this.log4NetAdapter.Info(message);
        }

        public void LogInfo(string message, Exception exception)
        {
            this.log4NetAdapter.Info(message, exception);
        }

        public void LogWarning(string message)
        {
            this.log4NetAdapter.Warn(message);
        }

        public void LogWarning(string message, Exception exception)
        {
            this.log4NetAdapter.Warn(message, exception);
        }
    }
    
    public class ExampleClass
    {
        private readonly Logger logger = new Logger(typeof(ExampleClass));
    
        public ExampleClass()
        {
             
        }
        
    }
    
    class Program
    {
        private static readonly Logger logger = new Logger(typeof(Program));

        static void Main(string[] args)
        {
            
            
        }   
    }   
}
