using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BirthClinicPlanningDB;
using BirthClinicPlanningDB.DomainObjects;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class SpecificAppointmentViewModel : BindableBase, IDialogAware
    {
        public Appointment Appointment { get; set; }
        private IDataAccessActions access = new DataAccessActions(new Context());
        private IDialogService _dialog;
        public ObservableCollection<string> RoomType { get; set; }
        public int RoomTypeIndex { get; set; }

        public SpecificAppointmentViewModel(IDialogService dialog)
        {
            _dialog = dialog;
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            int id = int.Parse(parameters.GetValue<string>("Message"));
            Appointment = access.Appointments.getSingleAppointment(id);
            access.Complete();
            RoomType = new ObservableCollection<string>() { "Birth Room", "Maternity Room", "Rest Room" };
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;

        private ICommand _checkout;

        public ICommand Checkout
        {
            get
            {
                return _checkout ?? (_checkout = new DelegateCommand(CheckoutExecute));
            }
        }

        private void CheckoutExecute()
        {
            Room roomToCopy = Appointment.Room;

            switch (Appointment.Room.RoomType)
            {
                case "Rest Room":
                    Appointment.Room = new BirthRoom();
                    Appointment.Room.Child = new Child();
                    Appointment.Room.Clinicians = roomToCopy.Clinicians;
                    Appointment.Room.Parents = roomToCopy.Parents;
                    Appointment.Room.Occupied = roomToCopy.Occupied;
                    Appointment.Room.RoomNumber = roomToCopy.RoomNumber;
                    Appointment.BirthInProgess = true;
                    break;

                case "Birth Room":
                    Appointment.Room = new MaternityRoom();
                    _dialog.Show("BabyInformationView");
                    Appointment.Room.Child = ((App)Application.Current).Child;
                    Appointment.Room.Clinicians.Clear();
                    Appointment.Room.Parents = roomToCopy.Parents;
                    Appointment.Room.Occupied = roomToCopy.Occupied;
                    Appointment.Room.RoomNumber = roomToCopy.RoomNumber;
                    Appointment.BirthInProgess = false;
                    break;

                case "Maternity Room":
                    access.Appointments.DelAppointment(Appointment.AppointmentID);
                    break;
            }
        }
    }
}
