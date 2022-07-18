using System;
using WikipediaSpeedrunGame.ViewModel;
using WikipediaSpeedrunGame.WikipediaPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikipediaSpeedrunGame
{
    public partial class GamePage : ContentPage
    {
        private SpeedrunModelView _speedrunModelView;
 
        public GamePage(SpeedrunModelView modelView)
        {
            InitializeComponent();
            _speedrunModelView = modelView;
            BindingContext = _speedrunModelView;
        }
    }
}