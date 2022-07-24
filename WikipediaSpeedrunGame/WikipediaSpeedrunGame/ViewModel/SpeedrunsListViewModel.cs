using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame.ViewModel
{
	class SpeedrunsListViewModel : BaseViewModel
	{
		public ICommand ItemSelectedCommand { get; set; }
		public ICommand ItemTappedCommand { get; set; }
		public ObservableCollection<SpeedrunInfo> SavedSpeedruns { get; set; }

		public SpeedrunsListViewModel()
		{
			ItemSelectedCommand = new Command(ItemSelected);
			ItemTappedCommand = new Command(ItemTapped);

			SavedSpeedruns = WikipediaSpeedrunGame.SavedSpeedruns.SavedList;
		}

		private void ItemSelected(object parameter)
		{
			
		}

		private async void ItemTapped(object parameter)
		{
			if (((ItemTappedEventArgs)parameter).Item is SpeedrunInfo selectedSpeedrun)
			{
				Page startPage = selectedSpeedrun.StartPage;
				Page finishPage = selectedSpeedrun.FinishPage;
				bool result = await Application.Current.MainPage.DisplayAlert("Speedrun info",
					$"{startPage.Title} - {startPage.Type}\n{finishPage.Title} - {finishPage.Type}\n" +
					$"Jumps Number: {selectedSpeedrun.JumpsNumber}", "OK", "Delete");
				if(!result)
				{
					WikipediaSpeedrunGame.SavedSpeedruns.SavedList.Remove(selectedSpeedrun);
				}
			}
		}
	}
}
