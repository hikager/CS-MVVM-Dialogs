using GalaSoft.MvvmLight.Command;
using MvvmDialogs.ViewModels;
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
    public class DialogWindowViewModel : INotifyPropertyChanged, IUserDialogViewModel
    {
        #region propietats
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
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



        #region commands

        public event EventHandler DialogClosing;

        public ICommand OkCommand => new RelayCommand(Ok);

        /// <summary>
        /// When Ok pressed passing a non null object from the class
        /// </summary>
        public void Ok()
        {
            if (this.OnOk != null)
            {
                this.OnOk(this);
            }
            Close();
        }

        public ICommand CancelCommand => new RelayCommand(Cancel);

        /// <summary>
        /// When  cancel  pressed passing a non null object from the class
        /// </summary>
        public void Cancel()
        {
            if (this.OnCancel != null)
            {
                this.OnCancel(this);
            }
            Close();
        }


        /// <summary>
        /// When the windows is going to close (by exit without button), it action triggers this method. As it's call, it requests to close.
        /// </summary>
        public void RequestClose()
        {
            if (this.OnCloseRequest != null)
            {
                this.OnCloseRequest(this);
            }
            Close();
        }


        /// <summary>
        /// Closing action.
        /// </summary>
        public void Close()
        {
            if (this.DialogClosing != null)
            {
                this.DialogClosing(this, new EventArgs());
            }
        }

        //Actions - Button Ok
        public Action<DialogWindowViewModel> OnOk { get; set; }
        //Actions - Button Cancel
        public Action<DialogWindowViewModel> OnCancel { get; set; }
        //Actions - Exit from dialog without button
        public Action<DialogWindowViewModel> OnCloseRequest { get; set; }
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
