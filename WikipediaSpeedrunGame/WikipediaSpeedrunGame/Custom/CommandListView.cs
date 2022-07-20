using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace WikipediaSpeedrunGame.Custom
{
	class CommandListView : ListView
	{
		public static readonly BindableProperty ItemSelectedCommandProperty =
				   BindableProperty.Create(nameof(ItemSelectedCommand), typeof(ICommand), typeof(CommandListView), null);
		public static readonly BindableProperty ItemTappedCommandProperty =
				   BindableProperty.Create(nameof(ItemTappedCommand), typeof(ICommand), typeof(CommandListView), null);

		public ICommand ItemSelectedCommand
		{
			get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
			set { SetValue(ItemSelectedCommandProperty, value); }
		}

		public CommandListView()
		{
			ItemSelected += (s, e) =>
			{
				if (ItemSelectedCommand?.CanExecute(e) ?? false)
					ItemSelectedCommand.Execute(e);
			};

			ItemTapped += (s, e) =>
			{
				if (ItemTappedCommand?.CanExecute(e) ?? false)
					ItemTappedCommand.Execute(e);
			};
		}

		public ICommand ItemTappedCommand
		{
			get { return (ICommand)GetValue(ItemTappedCommandProperty); }
			set { SetValue(ItemTappedCommandProperty, value); }
		}
	}
}
