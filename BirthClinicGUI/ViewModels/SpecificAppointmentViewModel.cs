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
        private Appointment _appointment;
        public Appointment Appointment { get => _appointment; set => SetProperty(ref _appointment, value); }
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
            Appointment.Room.Occupied = false;

            switch (Appointment.Room.RoomType)
            {
                case "Rest Room":
                    ChangeToBirthRoom();
                    break;

                case "Birth Room":
                    ChangeToMaternityRoom();
                    break;

                case "Maternity Room":
                    access.Appointments.DelAppointment(Appointment.AppointmentID);
                    access.Complete();
                    break;
            }
        }

        private void ChangeToBirthRoom()
        {
            Room roomToCopy = Appointment.Room;
            ObservableCollection<BirthRoom> birthRooms = access.BirthRooms.GetAllBirthsRooms();

            foreach (var birthroom in birthRooms)
            {
                if (!birthroom.Occupied)
                {
                    Appointment.Room = birthroom;
                }
            }

            Appointment.Room.Child = roomToCopy.Child;
            Appointment.Room.Parents = roomToCopy.Parents;
            Appointment.Room.Clinicians = roomToCopy.Clinicians;
            Appointment.Room.Occupied = true;
            Appointment.BirthInProgess = true;
            
            access.Complete();
        }

        private void ChangeToMaternityRoom()
        {
            Room roomToCopy = Appointment.Room;
            ObservableCollection<MaternityRoom> maternityRooms = access.MaternityRooms.GetAllMaternityRooms();

            foreach (var maternityRoom in maternityRooms)
            {
                if (!maternityRoom.Occupied)
                {
                    Appointment.Room = maternityRoom;
                }
            }

            Appointment.Room.Child = roomToCopy.Child;
            Appointment.Room.Parents = roomToCopy.Parents;
            Appointment.Room.Clinicians.Clear();
            Appointment.Room.Occupied = true;
            Appointment.BirthInProgess = false;

            access.Complete();
        }
    }
}
