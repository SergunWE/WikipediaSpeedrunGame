using System;
using WikipediaSpeedrunGame.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikipediaSpeedrunGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
            Console.WriteLine("Game started");
            BindingContext = new SpeedrunModelView();
        }

        void WebViewNavigating(object sender, WebNavigatingEventArgs e)
        {
            if(!((SpeedrunModelView)BindingContext).SwitchPage(e.Url))
            {
                e.Cancel = true;
            }
            if(((SpeedrunModelView)BindingContext).CheckPage())
            {
                Console.WriteLine("Game finished");
                DisplayAlert("Уведомление", "Вы нашли необходимую страницу", "ОK");
            }
            
        }
    }
}