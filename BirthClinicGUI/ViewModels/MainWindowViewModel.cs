using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;
using BirthClinicPlanningDB;
using BirthClinicPlanningDB.DomainObjects;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private IDialogService _dialog;
        private ObservableCollection<Appointment> _appointments;
        private IDataAccessActions access = new DataAccessActions(new Context());

        private int _appointmentIndex;
        public int AppointmentIndex
        {
            get => _appointmentIndex;
            set => SetProperty(ref _appointmentIndex, value);
        }

        public ObservableCollection<Appointment> Appointments
        {
            get => _appointments;
            set => _appointments = value;
        }

        public MainWindowViewModel(IDialogService dialog)
        {
            _dialog = dialog;
            Appointments = access.Appointments.getAllAppointments();
            access.Complete();
            AppointmentIndex = 0;
        }

        private ICommand _addAppointmentCommand;

        public ICommand AddAppointmentCommand
        {
            get
            {
                return _addAppointmentCommand ??
                       (_addAppointmentCommand = new DelegateCommand(AddAppointmentCommandExecute));
            }
        }

        private void AddAppointmentCommandExecute()
        {
            _dialog.ShowDialog("AddAppointmentView", r =>
            {
                Appointments = access.Appointments.getAllAppointments();
                access.Complete();
            });
        }

        private ICommand _selectAppointmentCommand;

        public ICommand SelectAppointmentCommand
        {
            get
            {
                return _selectAppointmentCommand ??
                       (_selectAppointmentCommand = new DelegateCommand(SelectAppointmentCommandExecute));
            }

        }

        private void SelectAppointmentCommandExecute()
        {
            string id = Appointments[AppointmentIndex].AppointmentID.ToString();
            _dialog.ShowDialog("SpecificAppointmentView", new DialogParameters($"Message={id}"), r =>
            {
            });
        }

        private ICommand _statusRoomsCommand;

        public ICommand StatusRoomsCommand
        {
            get
            {
                return _statusRoomsCommand ?? (_statusRoomsCommand = new DelegateCommand(StatusRoomsCommandExecute));
            }

        }

        private void StatusRoomsCommandExecute()
        {
            _dialog.ShowDialog("StatusRoomsView", r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    if (r.Result == ButtonResult.OK)
                    {
                        Appointments = access.Appointments.getAllAppointments();
                        access.Complete();
                    }
                }
            });
        }
    }
}
