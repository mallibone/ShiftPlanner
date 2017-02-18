using Microsoft.Practices.ServiceLocation;
using ShiftPlanner.ViewModels;
using Xamarin.Forms;

namespace ShiftPlanner.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = Vm;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private MainViewModel Vm => App.Locator.MainViewModel;
    }
}
