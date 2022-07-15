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
        private SpeedrunInfo _data;

        public event PropertyChangedEventHandler PropertyChanged;

        public SpeedrunModelView()
        {
            _data = new SpeedrunInfo();
        }

        public string StartPageUrl
        {
            get { return _data.StartPageUrl; }
            set
            {
                if (_data.StartPageUrl != value)
                {
                    _data.StartPageUrl = value;
                    OnPropertyChanged("StartPageUrl");
                }
            }
        }

        public string StartPageTitle
        {
            get { return _data.StartPageTitle; }
            set
            {
                if (_data.StartPageTitle != value)
                {
                    _data.StartPageTitle = value;
                    OnPropertyChanged("StartPageTitle");
                }
            }
        }

        public string RequiredPageTitle
        {
            get { return _data.RequiredPageTitle; }
            set
            {
                if (_data.RequiredPageTitle != value)
                {
                    _data.RequiredPageTitle = value;
                    OnPropertyChanged("RequiredPageTitle");
                }
            }
        }

        public bool CanSwitchPage(string newUrl)
        {
            return newUrl.Contains("wikipedia.org/wiki/");
        }

        public bool CheckPage(string url)
        {
            return Page.GetPageTitle(url) == RequiredPageTitle;
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
