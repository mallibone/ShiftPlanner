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

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            Vm.ItemSelected((DayViewModel) e.SelectedItem);

            MonthlyShifts.SelectedItem = null;
        }
    }
}
