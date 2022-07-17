using System.Windows.Input;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame.ViewModel
{
    class SpeedrunModelView : BaseViewModel
    {
        public ICommand NavigatingCommand { get; set; }
        public ICommand NavigatedCommand { get; set; }

        private SpeedrunInfo _data;
        private string _currentUrl;

        public SpeedrunModelView()
        {
            _data = new SpeedrunInfo();
            _currentUrl = _data.StartPageUrl;
            NavigatingCommand = new Command(WebViewNavigating);
            NavigatedCommand = new Command(WebViewNavigated);
        }

        public string CurrentPageUrl
        {
            get { return _currentUrl; }
            set
            {
                if (_currentUrl != value)
                {
                    _currentUrl = value;
                    OnPropertyChanged("CurrentPageUrl");
                }
            }
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

        public string RequiredPageTitle
        {
            get { return _data.RequiredPageTitle.Replace('_', ' '); }
            set
            {
                if (_data.RequiredPageTitle != value)
                {
                    _data.RequiredPageTitle = value;
                    OnPropertyChanged("RequiredPageTitle");
                }
            }
        }

        public int JumpsNumber
        {
            get { return _data.JumpsNumber; }
            set
            {
                if (_data.JumpsNumber != value)
                {
                    _data.JumpsNumber = value;
                    OnPropertyChanged("JumpsNumber");
                }
            }
        }

        private void WebViewNavigating(object parameter)
        {
            WebNavigatingEventArgs eventArgs = (WebNavigatingEventArgs)parameter;
            string newUrl = eventArgs.Url;
            if (Page.IsWikipediaPage(newUrl))
            {
                if (Page.GetPageTitle(CurrentPageUrl) != Page.GetPageTitle(newUrl)) JumpsNumber++;
                CurrentPageUrl = newUrl;
                return;
            }
            eventArgs.Cancel = true;
        }

        private void WebViewNavigated(object parameter)
        {

        }
    }
}
