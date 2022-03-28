using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Models
{
    public class Room
    {
        private static int _idCounter;
        private double _price;
        private int _personCapacity;
        public int Id { get; private set; }
        public string Name { get; set; }
        public double Price { get { return _price; } set { if (value > 0) _price = value; } }
        public int PersonCapacity { get { return _personCapacity; } set { if (value > 0 && value < 20) _personCapacity = value; } }
        public bool IsAvailable { get; set; }
        static Room()
        {
            _idCounter = 0;
        }
        public Room(string name, double price, int personCapacity)
        {
            Id = ++_idCounter;
            Name = name;
            Price = price;
            PersonCapacity = personCapacity;
        }
        public Room(string name, double price, int personCapacity, bool isAvailable) : this(name, price, personCapacity)
        {
            IsAvailable = isAvailable;
        }
        public string ShowInfo()
        {
            string available;
            if (IsAvailable is true) available = "yes"; else available = "no";
            return $"Id: {Id}\nName: {Name}\nPrice: {Price}$\nPerson capacity: {_personCapacity}\nIs available?: {available}";
        }
        public override string ToString()
        {
            return ShowInfo();
        }
    }
}
