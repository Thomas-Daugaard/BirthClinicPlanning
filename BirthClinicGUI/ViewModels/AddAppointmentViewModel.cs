using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using BirthClinicPlanningDB;
using BirthClinicPlanningDB.DomainObjects;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class AddAppointmentViewModel : BindableBase, IDialogAware
    {
        public Appointment Appointment { get; set; }
        public ObservableCollection<Clinician> Clinicians { get; set; }
        public int ClinicianIndex { get; set; }
        public ObservableCollection<Clinician> AllClinicians { get; set; }

        private bool _okButtonPressed;

        private IDataAccessActions access = new DataAccessActions(new Context());

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            if (_okButtonPressed)
            {
                Appointment.Room.Child.BirthDate = Appointment.Date;
                access.Appointments.AddAppointment(Appointment);
                access.Complete();
            }
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Appointment = new Appointment() {BirthInProgess = false, Date = DateTime.Now.Date, Room = new Room() {Parents = new Parents(), Child = new Child(), Clinicians = new ObservableCollection<Clinician>()}};
            Clinicians = new ObservableCollection<Clinician>();
            AllClinicians = access.Clinicians.GetAllClinicians();
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
            {
                result = ButtonResult.OK;
                _okButtonPressed = true;
            }
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.Cancel;

            if (Appointment.Room.Parents.MomCPR == "" || Appointment.Room.RoomID == 0)
                MessageBox.Show("Please fill out all required fields", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            else
                RequestClose(new DialogResult(result));
        }


        private ICommand _addClinicianFromList;


        public ICommand AddClinicianFromList
        {
            get
            {
                return _addClinicianFromList ?? (_addClinicianFromList = new DelegateCommand(AddClinicianFromListExcecute));
            }
        }

        private void AddClinicianFromListExcecute()
        {
            Clinician clinician = AllClinicians[ClinicianIndex];
            Clinicians.Add(clinician);

            string message = "";

            foreach (var staff in Clinicians)
            {
                message += string.Join(", ", $"\n{staff.FirstName} {staff.LastName}");
            }

            MessageBox.Show($"Currently added Clinicians:\n {message}", "Clinician added to appointment", MessageBoxButton.OK);
        }
    }
}
