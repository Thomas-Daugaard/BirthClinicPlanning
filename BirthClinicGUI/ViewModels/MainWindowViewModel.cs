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

        public int CurrentClinitianIndex { get; set; }

        public ObservableCollection<Appointment> Appointments
        {
            get => _appointments;
            set => _appointments = value;
        }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(IDialogService dialog)
        {
            _dialog = dialog;

            #if DEBUG
            Appointments = new ObservableCollection<Appointment>()
            {
                new ()
                    {
                        DadCPR = "250485-1234",
                        MomCPR = "010186-1234",
                        Date = DateTime.Now.Date,
                        BirthInProgess = true,
                        Clinicians = new ObservableCollection<Clinician>()
                        {
                            new () { ID = 1, FirstName = "Jørgen", LastName = "Hansen"},
                            new () {ID = 2, FirstName = "Tove", LastName = "Andersen"},
                            new () {ID = 3, FirstName = "Ole", LastName = "Damsgaard"}
                        }
                    }
            };
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
    }
}
