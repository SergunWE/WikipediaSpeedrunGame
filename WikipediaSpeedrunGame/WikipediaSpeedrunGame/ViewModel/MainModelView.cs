using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WikipediaSpeedrunGame.View;
using WikipediaSpeedrunGame.WikipediaPage;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame.ViewModel
{
	public class MainModelView : BaseViewModel
	{
		private PageType _startPageType;
		private PageType _finishPageType;
		public ICommand StartGameCommand { get; set; }
		public ICommand ShowSavedSpeedrunsCommand { get; set; }

		public INavigation Navigation { get; set; }

		public MainModelView()
		{
			StartGameCommand = new Command(StartGame);
			ShowSavedSpeedrunsCommand = new Command(ShowSavedSpeedruns);
			_startPageType = PageType.Random;
			_finishPageType = PageType.Random;
		}

		public int StartPageTypeIndex
		{
			get => (int)_startPageType;
			set
			{
				if ((int)_startPageType != value)
				{
					_startPageType = (PageType)value;
					OnPropertyChanged("StartPageTypeIndex");
				}
			}
		}

		public int FinishPageTypeIndex
		{
			get => (int)_finishPageType;
			set
			{
				if ((int)_finishPageType != value)
				{
					_finishPageType = (PageType)value;
					OnPropertyChanged("FinishPageTypeIndex");
				}
			}
		}

		private void StartGame()
		{
			Navigation.PushModalAsync(new GamePage(new SpeedrunModelView(
				new SpeedrunInfo(new Page(_startPageType), new Page(_finishPageType)))));
		}

		private void ShowSavedSpeedruns()
		{
			Navigation.PushAsync(new ResultPage());
		}
	}
}
