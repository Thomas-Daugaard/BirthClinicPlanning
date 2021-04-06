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

        public int CurrentClinitianIndex { get; set; }

        public ObservableCollection<Appointment> Appointments
        {
            get => _appointments;
            set => _appointments = value;
        }

        public MainWindowViewModel(IDialogService dialog)
        {
            _dialog = dialog;

            #if DEBUG
            Appointment appointment = new()
            {
                Date = DateTime.Now.Date,
                BirthInProgess = true,
                Clinicians = new ObservableCollection<Clinician>()
                {
                    new() {FirstName = "Jørgen", LastName = "Hansen"},
                    new() {FirstName = "Tove", LastName = "Andersen"},
                    new() {FirstName = "Ole", LastName = "Damsgaard"}
                },
                Parents = new Parents()
                {
                    DadCPR = "250485-1234",
                    DadFirstName = "Thomas",
                    DadLastName = "Daugaard",
                    MomCPR = "010186-1234",
                    MomFirstName = "Jennifer",
                    MomLastName = "Meldgaard"
                }

            };

            access.Appointments.AddAppointment(appointment);
            Appointments = access.Appointments.getAllAppointments();
            access.Complete();
            AppointmentIndex = 0;
            #endif
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
                if (r.Result == ButtonResult.OK)
                {
                    // call update method on EF core rep in release version
                }
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
