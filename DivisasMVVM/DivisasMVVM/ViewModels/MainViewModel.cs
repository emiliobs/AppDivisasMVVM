using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace DivisasMVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        #region Attributes

        private decimal dollar;

        private decimal euros;

        private decimal pounds;

        #endregion

        #region Properties

        public decimal Pounds
        {
            get
            {
                return pounds;

            }


            set
            {

                if (pounds != value)
                {
                    pounds = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pounds"));
                }
            }
        }


        public decimal Euros
        {
            get
            {
                return euros;

            }


            set
            {

                if (euros != value)
                {
                    euros = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Euros"));
                }
            }
        }

        public decimal Dollar
        {
            get
            {
                return dollar;

            }


            set
            {

                if (dollar != value)
                {
                    dollar = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dollar"));
                }
            }
        }

        public decimal Pesos { get; set; }

        #endregion

        #region Commands

        public ICommand ConverterCommand
        {
            get { return new RelayCommand(ConvertMoney); }
        }

        private async void ConvertMoney()
        {
            if (Pesos <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Error.....", "Debe ingresar un valor mayor a cero en pesos.....",
                    "Acept");

               return;
            }


            Dollar = Pesos / 2849.00285M;
            Euros  = Pesos / 3072.79202M;
            Pounds = Pesos / 3557.26496M;
        }

        #endregion


        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion

    }
}
