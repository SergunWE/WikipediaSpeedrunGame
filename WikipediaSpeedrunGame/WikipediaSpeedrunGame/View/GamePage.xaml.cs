using System;
using WikipediaSpeedrunGame.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikipediaSpeedrunGame
{
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
            BindingContext = new SpeedrunModelView();
        }
    }
}