using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using Training3.Model;

namespace Training3.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        #region Fields
        CargoGenerator generator;
        private CargoVM selectedCargo;
        bool started = false;
        private ObservableCollection<CargoVM> cargo;
        private ObservableCollection<CargoVM> arrived;
        private ObservableCollection<CargoVM> detail;
        private RelayCommand startBtnClick;
        private RelayCommand clearBtnClick;
        private RelayCommand stopBtnClick;
        private RelayCommand selectBtnClick;
        #endregion

        #region Properties
        public RelayCommand SelectBtnClick
        {
            get { return selectBtnClick; }
            set { selectBtnClick = value; }
        }

        public RelayCommand StartBtnClick
        {
            get { return startBtnClick; }
            set { startBtnClick = value; RaisePropertyChanged(); }
        }

        public RelayCommand ClearBtnClick
        {
            get { return clearBtnClick; }
            set { clearBtnClick = value; RaisePropertyChanged(); }
        }

        public RelayCommand StopBtnClick
        {
            get { return stopBtnClick; }
            set { stopBtnClick = value; RaisePropertyChanged(); }
        }

        public CargoVM SelectedCargo
        {
            get { return selectedCargo; }
            set { selectedCargo = value; }
        }

        public ObservableCollection<CargoVM> Cargo
        {
            get { return cargo; }
            set { cargo = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<CargoVM> Detail
        {
            get { return detail; }
            set { detail = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<CargoVM> Arrived
        {
            get { return arrived; }
            set { arrived = value; RaisePropertyChanged(); }
        }
        #endregion

        public MainViewModel()
        {
            
            Cargo = new ObservableCollection<CargoVM>();
            Detail = new ObservableCollection<CargoVM>();
            Arrived = new ObservableCollection<CargoVM>();
            
            StartBtnClick = new RelayCommand(()=> 
            {
                generator = new CargoGenerator(GenerateCargo);
                generator.StartGenerating();
                started = true;
            }, ()=> { return !started; });

            StopBtnClick = new RelayCommand(() =>
            {
                generator.StopGenerating();
                started = false;
            }, () => { return started; });

            ClearBtnClick = new RelayCommand(() =>
            {
                Cargo.Clear();
            }, () => { return Arrived.Count > 0; });

            SelectBtnClick = new RelayCommand(() =>
            {
                RaisePropertyChanged("SelectedCargo");
            }, () => { return Arrived.Count > 0; });
        }

        #region Methods
        private void GenerateCargo()
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Cargo.Add(new CargoVM(DeliveryCargo));
            });
        }

        private void DeliveryCargo(CargoVM arrivedCargo)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Cargo.Remove(arrivedCargo);
                Arrived.Add(arrivedCargo);
            });

        }
        #endregion
    }
}