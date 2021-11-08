using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExampleCalculator.ViewModel
{

    

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string input;

        public string Input
        {
            get { return input; }
            set { input = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand inputCommand;

        public ICommand InputCommand
        {
            get {
                if(inputCommand == null)
                {
                    inputCommand = new RelayCommand(x => ProccessInput(x));
                }
                return inputCommand; }
            set { inputCommand = value; }
        }

        private void ProccessInput(object x)
        {
            Input += x.ToString();
        }
    }



}
