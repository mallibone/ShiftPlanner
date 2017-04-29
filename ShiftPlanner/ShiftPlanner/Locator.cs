using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Plugin.Calendars;
using Plugin.Calendars.Abstractions;
using ShiftPlanner.Repository;
using ShiftPlanner.Services;
using ShiftPlanner.ViewModels;

namespace ShiftPlanner
{
    internal class Locator
    {
        static Locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //Services
            SimpleIoc.Default.Register<ICalendars>(() => CrossCalendars.Current);
            SimpleIoc.Default.Register<CalendarService>();
            SimpleIoc.Default.Register<ShiftService>();

            // Repositories
            SimpleIoc.Default.Register<IShiftRepository, ShiftRepository>();
            SimpleIoc.Default.Register<CalendarRepository>();

            //ViewModels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ChooseCalendarViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ChooseCalendarViewModel ChooseCalendarViewModel => ServiceLocator.Current.GetInstance<ChooseCalendarViewModel>();
    }
}
