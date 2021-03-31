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
using BirthClinicGUI.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class AddAppointmentViewModel : BindableBase, IDialogAware
    {
        public Appointment Appointment { get; set; }
        public ObservableCollection<Clinician> Clinicians { get; set; }
        public string ClinicianFirstName { get; set; }
        public string ClinicianLastName { get; set; }
        public int ClinicianID { get; set; }

        private bool _okButtonPressed = false;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            Appointment.Clinicians = Clinicians;
            Appointment.Child.BirthDate = Appointment.Date;
            ((App) Application.Current).Appointment = Appointment;
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Appointment = new Appointment() {BirthInProgess = false, Date = DateTime.Now.Date, Parents = new Parents(), Child = new Child()};
            Clinicians = new ObservableCollection<Clinician>();
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

            if (Appointment.Parents.MomCPR == "" || Appointment.RoomID == 0 || Clinicians.Count == 0)
                MessageBox.Show("Please fill out all required fields", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            else
                RequestClose(new DialogResult(result));
        }

        private ICommand _addClinician;
        

        public ICommand AddClinician
        {
            get
            {
                return _addClinician ?? (_addClinician = new DelegateCommand(AddClinicianCanExcecute));
            }
        }

        private void AddClinicianCanExcecute()
        {
            if (ClinicianID == 0 || (ClinicianFirstName == "" || ClinicianLastName == ""))
                MessageBox.Show("Please fill out all required fields", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            else
            {
                Clinicians.Add(new Clinician() { ID = ClinicianID, FirstName = ClinicianFirstName, LastName = ClinicianLastName});
                MessageBox.Show("Clinician " + ClinicianFirstName + " " + ClinicianLastName + " added", "Clinician added", MessageBoxButton.OK);
            }
        }
    }
}
