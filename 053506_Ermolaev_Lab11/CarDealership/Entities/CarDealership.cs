using System;
using System.Linq;
using System.Collections.Generic;

namespace Entities
{
    public class CarDealership
    {

        public CarDealership()
        {
            Name = default(string);
            ID = 0;
            _cars = new List<Car>();
        }
        public CarDealership(string name)
        {
            Name = name;
            ID = name.GetHashCode();
            _cars = new List<Car>();
        }

        public string Name { get; set; }
        public int ID { get; }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public int Count()
        {
            return _cars.Count;
        }

        public static bool isNeedCar(Car car)
        {
            if (car.EngineCapacity > 2.0)
                return true;
            return false;
        }

        public int GetStatistics()
        {
            int count = (from car in _cars
                     where car.EngineCapacity > 2.0
                     select car).Count();
            return count;
        }
        public Car this[int index]
        {
            get
            {
                if (index < 0 || index >= _cars.Count)
                    throw new IndexOutOfRangeException();
                return _cars[index];
            }
            set
            {
                if (index < 0 || index >= _cars.Count)
                    throw new IndexOutOfRangeException();
                _cars[index] = value;
            }
        }
        public List<Car> Cars
        {
            get { return _cars; }
            set { _cars = value; }
        }

        private List<Car> _cars;
    }
}
