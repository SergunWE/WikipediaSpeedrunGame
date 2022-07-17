using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame.Custom
{
    /// <summary>
    /// Кастомный WebView, где добавлены команды на основе событий навигации для MVVM
    /// </summary>
    public class CommandWebView : WebView
    {
        public static readonly BindableProperty NavigatingCommandProperty =
            BindableProperty.Create(nameof(NavigatingCommand), typeof(ICommand), typeof(CommandWebView), null);

        public static readonly BindableProperty NavigatedCommandProperty =
            BindableProperty.Create(nameof(NavigatedCommand), typeof(ICommand), typeof(CommandWebView), null);

        public CommandWebView()
        {
            Navigating += (s, e) =>
            {
                if (NavigatingCommand?.CanExecute(e) ?? false)
                    NavigatingCommand.Execute(e);
            };

            Navigated += (s, e) =>
            {
                if (NavigatedCommand?.CanExecute(e) ?? false)
                    NavigatedCommand.Execute(e);
            };
        }

        public ICommand NavigatingCommand
        {
            get { return (ICommand)GetValue(NavigatingCommandProperty); }
            set { SetValue(NavigatingCommandProperty, value); }
        }

        public ICommand NavigatedCommand
        {
            get { return (ICommand)GetValue(NavigatedCommandProperty); }
            set { SetValue(NavigatedCommandProperty, value); }
        }
    }
}
