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
            BindingContext = new SpeedrunModelView();
        }

        void WebViewNavigating(object sender, WebNavigatingEventArgs e)
        {
            if(!((SpeedrunModelView)BindingContext).CanSwitchPage(e.Url))
            {
                e.Cancel = true;
                return;
            }
            if(((SpeedrunModelView)BindingContext).CheckPage(e.Url))
            {
                DisplayAlert("Уведомление", "Вы нашли необходимую страницу", "ОK");
            }
            
        }
    }
}