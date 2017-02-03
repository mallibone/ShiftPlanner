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

        private MainViewModel Vm => App.Locator.MainViewModel;
    }
}
