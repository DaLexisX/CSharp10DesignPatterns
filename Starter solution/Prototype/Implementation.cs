using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype
{
    /// <summary>
    /// Prototype
    /// </summary>
    public abstract class Person
    {
        public abstract string Name { get; set; }

        public abstract Person Clone(bool deepClone);
    }

    /// <summary>
    /// Concrete Prototype 1
    /// </summary>
    public class Manager : Person
    {
        public override string Name { get; set; }

        public Manager(string name)
        {
            Name = name;
        }

        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                //Deserialise has security concerns - no longer use
                /*var formatter = new BinaryFormatter();
                using (var stream = new MemoryStream())
                {
                    formatter.Serialize(stream, this);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (Person)formatter.Deserialize(stream);
                }*/

                //We'll use a JSON serialiser instead
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Manager>(objectAsJson);
            }
            return (Person)MemberwiseClone();
        }
    }

    /// <summary>
    /// Concrete Prototype 2
    /// </summary>
    public class Employee : Person
    {
        public Manager Manager { get; set; }
        public override string Name { get; set; }

        public Employee(string name, Manager manager)
        {
            Name = name;
            Manager = manager;
        }

        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                //Deserialise has security concerns - no longer use
                /*var formatter = new BinaryFormatter();
                using (var stream = new MemoryStream())
                {
                    formatter.Serialize(stream, this);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (Person)formatter.Deserialize(stream);
                }*/

                //We'll use a JSON serialiser instead
                var objectAsJson  = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Employee>(objectAsJson);
            }
            return (Person)MemberwiseClone();
        }
    }
}
