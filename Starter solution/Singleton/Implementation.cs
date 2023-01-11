namespace Singleton
{
    /// <summary>
    /// Singleton
    /// </summary>
    public class Logger
    {
        private static Logger _instance;
        private List<string> _logs = new List<string>();

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }

                return _instance;
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
