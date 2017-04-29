using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Calendars.Abstractions;
using ShiftPlanner.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShiftPlanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseCalendarPage : ContentPage
    {
        private ChooseCalendarViewModel Vm => App.Locator.ChooseCalendarViewModel;
        public ChooseCalendarPage()
        {
            InitializeComponent();
            BindingContext = Vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Vm.Init();
        }

        private void OnCalendarSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            // todo: act on selected item
            Vm.SelectedCalendar = (Calendar) e.SelectedItem;

            //CalendarsListView.SelectedItem = null;
        }
    }
}
