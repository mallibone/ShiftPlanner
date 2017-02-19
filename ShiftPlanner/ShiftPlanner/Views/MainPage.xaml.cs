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

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            MonthlyShifts.SelectedItem = null;
        }

    }
}
