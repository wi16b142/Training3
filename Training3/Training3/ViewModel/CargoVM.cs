using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using Training3.Model;

namespace Training3.ViewModel
{
    public class CargoVM:ViewModelBase
    {
        Cargo cargo;
        Action<CargoVM> arrived;
        Timer timer;

        public CargoVM(Action<CargoVM> arrived)
        {
            cargo = new Cargo();
            Items = new ObservableCollection<CargoItem>();
            this.arrived = arrived;
            CopyItems();
            SimulateDelivery();
        }

        public CargoVM(CargoVM cargoVM)
        {
            this.cargo = cargoVM.cargo;
        }

        public String Destination
        {
            get => cargo.Destination;
        }

        public int Deliverytime
        {
            get => cargo.Deliverytime;
        }
        
        public ObservableCollection<CargoItem> Items { get; set; }

        private void CopyItems()
        {
            foreach(var item in cargo.Items)
            {
                Items.Add(item);
            }
        }

        private void SimulateDelivery()
        {
            timer = new Timer();
            timer.Interval = this.cargo.Deliverytime * 1000;
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
