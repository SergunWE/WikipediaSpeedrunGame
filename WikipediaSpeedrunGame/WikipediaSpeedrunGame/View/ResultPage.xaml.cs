using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikipediaSpeedrunGame.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikipediaSpeedrunGame.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultPage : ContentPage
	{
		public ResultPage()
		{
			InitializeComponent();
			BindingContext = new ResultViewModel();
		}
	}
}