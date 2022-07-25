using System;
using WikipediaSpeedrunGame.ViewModel;
using WikipediaSpeedrunGame.WikipediaPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikipediaSpeedrunGame
{
    public partial class GamePage : ContentPage
    {
        private GameViewModel _speedrunModelView;
 
        public GamePage(GameViewModel modelView)
        {
            InitializeComponent();
            _speedrunModelView = modelView;
            BindingContext = _speedrunModelView;
        }
    }
}