using System;
using System.Collections.Generic;
using System.Threading;

namespace Training3.Model
{
    public class Cargo
    {
        string[] destinations = new String[] { "Vienna", "Prague", "Berlin", "London", "Paris" };

        public List<CargoItem> Items { get; set; }

        public string Destination { get; set; }
        public int Deliverytime { get; set; }
        public int Capacity { get; set; }
        static Random rnd = new Random();

        public Cargo()
        {
            this.Items = new List<CargoItem>();
            this.Capacity = rnd.Next(1, 9);
            CreateItems(this.Capacity);
            this.Destination = destinations[rnd.Next(0, 4)];
            this.Deliverytime = rnd.Next(1, 5);
        }

        private void CreateItems(int number)
        {
            for (int i = 0; i <= number; i++)
            {
                this.Items.Add(new CargoItem());
            }
        }
    }
}
