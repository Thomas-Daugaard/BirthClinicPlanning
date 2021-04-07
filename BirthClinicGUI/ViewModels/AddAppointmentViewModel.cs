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
        public int ClinicianIndex { get; set; }
        public ObservableCollection<Clinician> AllClinicians { get; set; }
        public ObservableCollection<string> RoomType { get; set; }
        public int RoomTypeIndex { get; set; }

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
                Room roomToCopy = Appointment.Room;

                switch (RoomType[RoomTypeIndex])
                {
                    case "Birth Room":
                        //if (Appointment.Room.RoomNumber >= 0 && Appointment.Room.RoomNumber <= 15)
                        //{
                        //    ObservableCollection<BirthRoom> tempRooms = access.BirthRooms.GetAllBirthsRooms();
                        //    foreach(BirthRoom br in tempRooms)
                        //    {
                        //        if(br.RoomID != roomToCopy.RoomID)
                        //        {
                        //            Appointment.Room = new BirthRoom();
                        //        }
                        //        else
                        //        {

                        //        }
                        //    }
                        //}
                        Appointment.Room = new BirthRoom();

                        break;
                    case "Maternity Room":
                        Appointment.Room = new MaternityRoom();
                        break;
                    case "Rest Room":
                        //int tempCount = 0;
                        //ObservableCollection<RestRoom> tempRestRoom = access.RestRooms.GetAllRestRoom();
                        //if (Appointment.Room.RoomNumber >=0 && Appointment.Room.RoomNumber <= 5)
                        //{
                        //    foreach(RestRoom RR in tempRestRoom)
                        //    {
                        //        foreach(Appointment ap in RR.Appointments)
                        //        {

                        //        }
                        //        if(RR.Occupied)
                        //        {
                        //            ++tempCount;
                        //        }
                        //    }
                        //    if (tempCount < 5)
                        //    {
                        //        access.RestRooms.AddRestRoom((RestRoom)roomToCopy);
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("All rooms occuoied at this time", "Error", 
                        //            MessageBoxButton.OK, MessageBoxImage.Error);
                        //    }
                        //    if (RR.Occupied != true)
                        //    {
                        //        Appointment.Room.Parents = roomToCopy.Parents;
                        //        Appointment.Room.Child = roomToCopy.Child;
                        //        Appointment.Room.Clinicians = roomToCopy.Clinicians;
                        //        Appointment.Room.Occupied = true;
                        //        access.Appointments.AddAppointment(Appointment);
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("Room occupied", "Error", MessageBoxButton.OK,
                        //            MessageBoxImage.Error);
                        //    }

                        //}
                        //else
                        //{
                        //    MessageBox.Show("Room does not exsist", "Error", MessageBoxButton.OK, 
                        //        MessageBoxImage.Error);
                        //}
                        Appointment.Room = new RestRoom();
                        break;
                }

                Appointment.Room.Child = roomToCopy.Child;
                Appointment.Room.Clinicians = roomToCopy.Clinicians;
                Appointment.Room.Parents = roomToCopy.Parents;
                Appointment.Room.Occupied = roomToCopy.Occupied;
                Appointment.Room.RoomNumber = roomToCopy.RoomNumber;

                Appointment.Room.Child.BirthDate = Appointment.Date;
                Appointment.Room.Occupied = true;
                access.Appointments.AddAppointment(Appointment);
                access.Complete();
            }
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Appointment = new Appointment() {BirthInProgess = false, Date = DateTime.Now.Date, Room = new BirthRoom() {Parents = new Parents(), Child = new Child(), Clinicians = new ObservableCollection<Clinician>()}};
            AllClinicians = access.Clinicians.GetAllClinicians();
            RoomType = new ObservableCollection<string>() {"Birth Room", "Maternity Room", "Rest Room"};
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

            if (Appointment.Room.Parents.MomCPR == "" || Appointment.Room.RoomNumber == 0)
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
            Appointment.Room.Clinicians.Add(clinician);

            string message = "";

            foreach (var staff in Appointment.Room.Clinicians)
            {
                message += string.Join(", ", $"\n{staff.FirstName} {staff.LastName}");
            }

            MessageBox.Show($"Currently added Clinicians:\n {message}", "Clinician added to appointment", MessageBoxButton.OK);
        }
    }
}
