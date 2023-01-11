namespace Singleton
{
    /// <summary>
    /// Singleton
    /// </summary>
    public class Logger
    {
        //Not thread safe
        //private static Logger _instance;

        //Lazy<T> - thread safe
        private static readonly Lazy<Logger> _lazyLogger = new Lazy<Logger>(() => new Logger());

        private List<string> _logs = new List<string>();

        public static Logger Instance
        {
            get
            {
                return _lazyLogger.Value;

                //if (_instance == null)
                //{
                //    _instance = new Logger();
                //}

                //return _instance;
            }
        }

        protected Logger() {
        
        }

        /// <summary>
        /// Singleton Operation
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            Console.WriteLine("Written to log: {0}", message);

            _logs.Add(message);
        }

        public void PrintLogs()
        {
            foreach (string log in _logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}
