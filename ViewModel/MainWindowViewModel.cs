using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
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

        #endregion


        #region commands for view buttons logic

        public ICommand BtnCommand => new RelayCommand<string>(NewDialog);
        public void NewDialog(string isModal) { }

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
