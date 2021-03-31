using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public string ClinicianName { get; set; }
        public int ClinicianID { get; set; }

        private bool _okButtonPressed = false;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            Appointment.Clinicians = Clinicians;
            ((App) Application.Current).Appointment = Appointment;
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Appointment = new Appointment();
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
            Clinicians.Add(new Clinician(){ID = ClinicianID, Name = ClinicianName});
            MessageBox.Show("Clinician " + ClinicianName + " added", "Clinician added", MessageBoxButton.OK);
        }
    }
}
