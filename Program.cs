using System.Reflection.Metadata.Ecma335;

namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Simple Logger

            Logger logger = Logger.Instance;
            Logger logger1 = Logger.Instance;
            
            if (logger == logger1 && logger.Equals(logger1))
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("Not Equals");
            }
        }

    }

    sealed class Logger
    {
        private static Logger _instance = null;
        private static readonly object _lock = new object();
        private static string? _LogFilePath;

        private Logger()
        {
            _LogFilePath = @"C:\Logs\dasdajklsdhnakjd.txt";
        }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            lock (_lock)
            {
                using(StreamWriter writer = new StreamWriter(_LogFilePath, true))
                {
                    writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:yyyy ") + message);
                }
            }
        }
    }
}