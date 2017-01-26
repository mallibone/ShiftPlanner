using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;

namespace ShiftPlanner.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = App.Locator.MainViewModel;

            InitializeComponent();
        }
    }
}
