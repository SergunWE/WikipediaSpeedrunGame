using System;
using System.Threading.Tasks;
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
        private int _stopWatchMinutes;
        private int _stopWatchSeconds;

        private bool _watchStopWorking;

        public GameViewModel(SpeedrunInfo info)
        {
            _model = info;
            _currentTitle = _model.StartPage.Title;
            _stopWatchMinutes = 0;
            _stopWatchSeconds = 0;
            NavigatingCommand = new Command(WebViewNavigating);
            NavigatedCommand = new Command(WebViewNavigated);
            Navigation = Application.Current.MainPage.Navigation;
            DisplayTime();
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

        public int StopWatchMinutes
        {
            get { return _stopWatchMinutes; }
            set
            {
                if (_stopWatchMinutes != value)
                {
                    _stopWatchMinutes = value;
                    OnPropertyChanged("StopWatchMinutes");
                }
            }
        }

        public int StopWatchSeconds
        {
            get { return _stopWatchSeconds; }
            set
            {
                if (_stopWatchSeconds != value)
                {
                    _stopWatchSeconds = value;
                    OnPropertyChanged("StopWatchSeconds");
                }
            }
        }

        private async void CheckPageToWin()
        {
            if (_currentTitle == _model.FinishPage.Title)
            {
                _model.FinishTime = DateTime.Now;
                _watchStopWorking = false;
                TimeSpan time = _model.FinishTime -_model.StartTime;
                StopWatchMinutes = (int)time.TotalMinutes;
                StopWatchSeconds = time.Seconds;
                bool result = await Application.Current.MainPage.DisplayAlert("You found the right page", $"Number of jumps: " +
                    $"{_model.JumpsNumber}\nTime: {_model.FinishTime - _model.StartTime}", "Save result", "Exit");
                if (result)
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

        private async void DisplayTime()
        {
            _watchStopWorking = true;
            TimeSpan time;
            while (_watchStopWorking)
            {
                time = CurrenntTimeSpeedrun();
                StopWatchMinutes = (int)time.TotalMinutes;
                StopWatchSeconds = time.Seconds;
                await Task.Delay(1000);
            }
        }

        private TimeSpan CurrenntTimeSpeedrun() => DateTime.Now - _model.StartTime;
    }
}
