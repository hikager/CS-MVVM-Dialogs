using GalaSoft.MvvmLight.Command;
using MvvmDialogs.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace m6.uf4.dialogs.proba02.git.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        #region properties for view

        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; NotifyPropertyChanged(); }
        }

        //Dialog list container
        private ObservableCollection<IDialogViewModel> _dialogList = new ObservableCollection<IDialogViewModel>();
        public ObservableCollection<IDialogViewModel> DialogList { get { return _dialogList; } }
        
        // windows dialog counter
        private int windowsNumeber = 0; 
        #endregion


        #region commands for view buttons logic

        public ICommand BtnCommand => new RelayCommand<string>(NewDialog);
        public void NewDialog(string isModal)
        {
            //Constructor with all the implementations within
            this.DialogList.Add(new DialogWindowViewModel()
            {
                IsModal = (isModal == "True"),
                Title = $"Dialog [{this.windowsNumeber++}] - Type [{(isModal == "True" ? "Modal" : "Non-Modal")}]",
                Text2 = Text //text dialog will get/grab the main view text  and will be set on it's own textbox.

            });;
        }

        #endregion


        #region notify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
