using Singleton;

Console.Title = "Singleton Pattern";

//Call the property getter twice
var instance1 = Logger.Instance;
var instance2 = Logger.Instance;

if (instance1 == Logger.Instance && instance2 == Logger.Instance)
{
    Console.WriteLine("Instances are the same.\r\n");
}

instance1.Log($"Message from {nameof(instance1)}");
instance2.Log($"Message from {nameof(instance2)}");
Logger.Instance.Log($"Message from {nameof(Logger.Instance)}\r\n");

Console.WriteLine("Dump of logs:\r\n");
instance1.PrintLogs();

Console.ReadLine();