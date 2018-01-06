using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Timers;

namespace Training3.Model
{
    public class CargoVM:ViewModelBase
    {
        string[] destinations = new String[] { "Vienna", "Prague", "Berlin", "London", "Paris" };

        public ObservableCollection<CargoItem> Items { get; set; }

        public string Destination { get; set; }
        public int Deliverytime { get; set; }
        public int Capacity { get; set; }
        static Random rnd = new Random();
        Action<CargoVM> arrived;
        Timer timer;

        public CargoVM(Action<CargoVM> arrived)
        {
            this.Items = new ObservableCollection<CargoItem>();
            this.Capacity = rnd.Next(1, 9);
            CreateItems(this.Capacity);
            this.Destination = destinations[rnd.Next(0, 4)];
            this.Deliverytime = rnd.Next(3, 10);
            this.arrived = arrived;
            SimulateDelivery();
        }

        private void CreateItems(int number)
        {
            for (int i = 0; i <= number; i++)
            {
                this.Items.Add(new CargoItem());
            }
        }

        private void SimulateDelivery()
        {
            timer = new Timer();
            timer.Interval = this.Deliverytime * 1000;
            timer.Elapsed += TimerElapsedEvent;
            timer.AutoReset = false;
            timer.Enabled = true;
        }

        private void TimerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            arrived(this);
            timer.Close();
        }
    }
}
