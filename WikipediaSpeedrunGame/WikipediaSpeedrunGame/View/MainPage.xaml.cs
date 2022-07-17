using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikipediaSpeedrunGame.ViewModel;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainModelView() { Navigation = this.Navigation };
        }
        /*private async void OnStartGameClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new GamePage());
        }*/
    }
}
