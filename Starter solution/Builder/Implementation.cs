﻿using System.Text;

namespace BuilderPattern
{
    /// <summary>
    /// Product
    /// </summary>
    public class Car
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;

        public Car(string carType)
        {
            _carType = carType;
        }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var part in _parts)
            {
                sb.Append($"Car of type: {_carType} has part {part}. ");
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// Builder
    /// </summary>
    public abstract class CarBuilder
    {
        public Car Car { get; private set; }

        public CarBuilder(string carType)
        {
            Car = new Car(carType);
        }

        public abstract void BuildEngine();
        public abstract void BuildFrame();
    }

    /// <summary>
    /// Concrete Builder 1
    /// </summary>
    public class MiniBuilder : CarBuilder
    {
        public MiniBuilder() : base("Mini")
        {

        }

        public override void BuildEngine()
        {
            Car.AddPart("'Not a v8'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'3-door with viper stripes'");
        }
    }

    /// <summary>
    /// Concrete Builder 2
    /// </summary>
    public class BMWBuilder : CarBuilder
    {
        public BMWBuilder() : base("BMW")
        {

        }

        public override void BuildEngine()
        {
            Car.AddPart("'A fancy v8 engine'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'5-door with metallic finish'");
        }
    }

    /// <summary>
    /// Director
    /// </summary>
    public class Garage
    {
        private CarBuilder? _builder;

        public Garage()
        {

        }

        public void Construct(CarBuilder builder)
        {
            _builder = builder;

            _builder.BuildEngine();
            _builder.BuildFrame();
        }

        public void Show()
        {
            Console.WriteLine(_builder?.Car.ToString());
        }
    }
}
