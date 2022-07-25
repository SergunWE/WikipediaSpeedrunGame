using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        public ICommand NavigatingCommand { get; set; }
        public ICommand NavigatedCommand { get; set; }

        public INavigation Navigation { get; set; }

        private SpeedrunInfo _model;
        private string _currentTitle;

        public GameViewModel(SpeedrunInfo info)
        {
            _model = info;
            _currentTitle = _model.StartPage.Title;
            NavigatingCommand = new Command(WebViewNavigating);
            NavigatedCommand = new Command(WebViewNavigated);
            Navigation = Application.Current.MainPage.Navigation;
        }

        public string StartPageUrl
        {
            get { return _model.StartPage.GetPageUrl(); }
        }

        public string FinishPageTitle
        {
            get { return _model.FinishPage.Title; }
        }

        public int JumpsNumber
        {
            get { return _model.JumpsNumber; }
            set
            {
                if (_model.JumpsNumber != value)
                {
                    _model.JumpsNumber = value;
                    OnPropertyChanged("JumpsNumber");
                }
            }
        }

        private async void CheckPageToWin()
		{
            if(_currentTitle == _model.FinishPage.Title)
			{
                _model.FinishTime = DateTime.Now;
                bool result = await Application.Current.MainPage.DisplayAlert("You found the right page", $"Number of jumps: " +
                    $"{_model.JumpsNumber}\nTime: {_model.FinishTime - _model.StartTime}", "Save result", "Exit");
                if(result)
				{
                    SavedSpeedruns.SavedList.Add(_model);
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
                if (_currentTitle != newTitle) JumpsNumber++;
                _currentTitle = newTitle;
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
