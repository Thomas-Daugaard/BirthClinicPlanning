using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;
using BirthClinicGUI.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private IDialogService _dialog;
        private ObservableCollection<Appointment> _appointments;

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
            Appointments = new ObservableCollection<Appointment>()
            {
                new ()
                    {
                        Date = DateTime.Now.Date,
                        BirthInProgess = true,
                        RoomID = 1,
                        Clinicians = new ObservableCollection<Clinician>()
                        {
                            new () { ID = 1, FirstName = "Jørgen", LastName = "Hansen"},
                            new () {ID = 2, FirstName = "Tove", LastName = "Andersen"},
                            new () {ID = 3, FirstName = "Ole", LastName = "Damsgaard"}
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
                        
                    }
            };
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
                    Appointments.Add(((App) Application.Current).Appointment);
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
            ((App) Application.Current).Appointment = Appointments[AppointmentIndex];
            _dialog.ShowDialog("SpecificAppointmentView", r =>
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
                    // call update method on EF core rep in release version
                }
            });
        }
    }
}
