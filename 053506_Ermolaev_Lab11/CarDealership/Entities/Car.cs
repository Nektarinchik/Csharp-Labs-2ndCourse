namespace Entities
{
    public class Car
    {
        public Car()
        {
            Name = default(string);
            EngineCapacity = default(double);
        }
        public Car(string name,double engineCapacity)
        {
            Name = name;
            EngineCapacity = engineCapacity;
        }
        public string Name { get; set; }
        public double EngineCapacity { get; set; }
    }
}
