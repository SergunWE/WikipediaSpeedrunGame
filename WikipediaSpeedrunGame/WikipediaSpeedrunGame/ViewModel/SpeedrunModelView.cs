using System.Windows.Input;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame.ViewModel
{
    public class SpeedrunModelView : BaseViewModel
    {
        public ICommand NavigatingCommand { get; set; }
        public ICommand NavigatedCommand { get; set; }

        public INavigation Navigation { get; set; }

        private SpeedrunInfo _data;
        private string _currentTitle;

        public SpeedrunModelView(SpeedrunInfo info)
        {
            _data = info;
            _currentTitle = _data.StartPage.Title;
            NavigatingCommand = new Command(WebViewNavigating);
            NavigatedCommand = new Command(WebViewNavigated);
            Navigation = App.Current.MainPage.Navigation;
        }

        public string CurrentPageTitle
        {
            get { return _currentTitle; }
            set
            {
                if (_currentTitle != value)
                {
                    _currentTitle = value;
                    OnPropertyChanged("CurrentPageTitle");
                }
            }
        }

        public string StartPageUrl
        {
            get { return _data.StartPage.GetPageUrl(); }
        }

        public string FinishPageTitle
        {
            get { return _data.FinishPage.Title; }
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

        private async void CheckPageToWin()
		{
            if(_currentTitle == _data.FinishPage.Title)
			{
                bool result = await Application.Current.MainPage.DisplayAlert("You found the right page", $"Number of jumps: {_data.JumpsNumber}", "Save result", "Exit");
                if(result)
				{
                    SpeedrunJsonSaver.AddToList(_data);
				}
                await Navigation.PopModalAsync();
			}
		}

        private void WebViewNavigating(object parameter)
        {
            WebNavigatingEventArgs eventArgs = (WebNavigatingEventArgs)parameter;
            string newUrl = eventArgs.Url;
            if (Page.IsWikipediaPage(newUrl))
            {
                string newTitle = Page.GetPageTitle(newUrl);
                if (CurrentPageTitle != newTitle) JumpsNumber++;
                CurrentPageTitle = newTitle;
                CheckPageToWin();
                return;
            }
            eventArgs.Cancel = true;
        }

        private void WebViewNavigated(object parameter)
        {

        }


    }
}
