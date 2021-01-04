using MvvmDialogs.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace m6.uf4.dialogs.proba02.git.ViewModel
{
    public class DialogWindowViewModel : INotifyPropertyChanged, IUserDialogViewModel
    {
        #region propietats
        private string _titol;
        public string Titol
        {
            get { return _titol; }
            set
            {
                _titol = value;
                NotifyPropertyChanged();
            }
        }

        private string _text;
        public string Text2
        {
            get { return _text; }
            set
            {
                _text = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsModal { get; set; }
        #endregion

        #region notify
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler DialogClosing;

        public void RequestClose()
        {
            throw new NotImplementedException();
        }

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
