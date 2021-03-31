using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BirthClinicGUI.Models;
using BirthClinicGUI.ViewModels;
using BirthClinicGUI.Views;
using Prism.Ioc;
using Prism.Unity;

namespace BirthClinicGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterDialog<AddAppointmentView, AddAppointmentViewModel>();
            containerRegistry.RegisterDialog<StatusRoomsView, StatusRoomsViewModel>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        public Appointment Appointment { get; set; }
    }
}
