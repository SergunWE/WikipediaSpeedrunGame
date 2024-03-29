﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikipediaSpeedrunGame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            SavedSpeedruns.SaveList();
        }

        protected override void OnResume()
        {
        }
    }
}
