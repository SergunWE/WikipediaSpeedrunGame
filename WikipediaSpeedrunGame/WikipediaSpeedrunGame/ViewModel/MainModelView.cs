using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame.ViewModel
{
    public class MainModelView : BaseViewModel
    {
        public ICommand StartGameCommand { get; set; }

        public INavigation Navigation { get; set; }

        public MainModelView()
        {
            StartGameCommand = new Command(StartGame);
        }

        private void StartGame()
        {
            Navigation.PushModalAsync(new GamePage());
        }
    }
}
