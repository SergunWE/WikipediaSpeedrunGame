using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame.ViewModel
{
    class SpeedrunModelView : INotifyPropertyChanged
    {
        private SpeedrunData _data;

        public event PropertyChangedEventHandler PropertyChanged;

        public SpeedrunModelView()
        {
            _data = new SpeedrunData();
        }

        public string StartPage
        {
            get { return _data.StartPage; }
            set
            {
                if (_data.StartPage != value)
                {
                    _data.StartPage = value;
                    OnPropertyChanged("StartPage");
                }
            }
        }

        public string CurrentPage
        {
            get { return _data.CurrentPage; }
            set
            {
                if (_data.CurrentPage != value)
                {
                    _data.CurrentPage = value;
                    OnPropertyChanged("CurrentPage");
                }
            }
        }

        public string RequiredPage
        {
            get { return _data.RequiredPage; }
            set
            {
                if (_data.RequiredPage != value)
                {
                    _data.RequiredPage = value;
                    OnPropertyChanged("RequiredPage");
                }
            }
        }

        public bool SwitchPage(string newUrl)
        {
            if(newUrl.Contains("wikipedia.org"))
            {
                CurrentPage = newUrl;
                return true;
            }
            return false;
        }

        public bool CheckPage()
        {
            return CurrentPage.Replace("m.", "") == RequiredPage;
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
