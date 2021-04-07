using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using BirthClinicPlanningDB;
using BirthClinicPlanningDB.DomainObjects;
using Itenso.TimePeriod;
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

        //public bool IsValidReservation(Appointment a1, Appointment a2)
        //{
        //    if (!TimeCompare.IsSameDay(a1.StartTime, a2.EndTime))
        //    {
        //        return false;  // multiple day reservation
        //    }

        //    TimeRange workingHours =
        //        new TimeRange(TimeTrim.Hour(a1.StartTime, a2.StartTime.Hour), TimeTrim.Hour(a1.EndTime, a2.EndTime));
        //    return workingHours.HasInside(new TimeRange(start, end));
        //} // IsValidReservation


        public bool ValidateDate(Appointment a1, Appointment a2)
        {
            TimeRange AppointmentToInsert = new TimeRange(a1.StartTime, a1.EndTime);
            TimeRange AppointmentToCompare = new TimeRange(a2.StartTime, a2.EndTime);


            if (AppointmentToCompare.IntersectsWith(AppointmentToInsert))
            {
                MessageBox.Show("Date already booked");
                return false;
            }

            else
                return true;
        }

        public void OnDialogClosed()
        {
            if (_okButtonPressed)
            {
                Room roomToCopy = Appointment.Room;

                switch (RoomType[RoomTypeIndex])
                {
                    case "Rest Room":
                        ObservableCollection<RestRoom> restRoomsToCheck = access.RestRooms.GetAllRestRoom();
                        access.Complete();

                        foreach (var room in restRoomsToCheck)
                        {
                            if (room.Appointments != null)
                            {
                                foreach (var appointment in room.Appointments)
                                {
                                    if (!ValidateDate(Appointment, appointment))
                                    {
                                        return;
                                    }
                                }
                            }
                            Appointment.Room = room;
                        }
                        break;

                    case "Birth Room":
                        ObservableCollection<BirthRoom> birthRoomsToCheck = access.BirthRooms.GetAllBirthsRooms();
                        access.Complete();

                        foreach (var room in birthRoomsToCheck)
                        {
                            foreach (var appointment in room.Appointments)
                            {
                                if (Appointment.StartTime >= DateTime.Now &&
                                    (DateTime.Compare(Appointment.StartTime, appointment.StartTime) < 0 ||
                                     DateTime.Compare(Appointment.EndTime, appointment.EndTime) > 0))
                                {
                                    Appointment.Room = appointment.Room;
                                    return;
                                }
                            }
                        }

                        MessageBox.Show("Room occucpied on selected date and time");

                        break;

                    case "Maternity Room":
                        ObservableCollection<MaternityRoom> maternityRoomsToCheck = access.MaternityRooms.GetAllMaternityRooms();
                        access.Complete();

                        foreach (var room in maternityRoomsToCheck)
                        {
                            foreach (var appointment in room.Appointments)
                            {
                                if (Appointment.StartTime >= DateTime.Now &&
                                    (DateTime.Compare(Appointment.StartTime, appointment.StartTime) < 0 ||
                                     DateTime.Compare(Appointment.EndTime, appointment.EndTime) > 0))
                                {
                                    Appointment.Room = appointment.Room;
                                    return;
                                }
                            }
                        }

                        MessageBox.Show("Room occucpied on selected date and time");
                        break;

                }

                Appointment.Room.Child = roomToCopy.Child;
                Appointment.Room.Clinicians = roomToCopy.Clinicians;
                Appointment.Room.Parents = roomToCopy.Parents;
                Appointment.Room.Occupied = roomToCopy.Occupied;
                Appointment.Room.RoomNumber = roomToCopy.RoomNumber;

                Appointment.Room.Occupied = true;
                access.Appointments.AddAppointment(Appointment);
                access.Complete();
            }
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Appointment = new Appointment() {BirthInProgess = false, StartTime = DateTime.Now.Date, Room = new BirthRoom() {Parents = new Parents(), Child = new Child(), Clinicians = new ObservableCollection<Clinician>()}};
            AllClinicians = access.Clinicians.GetAllClinicians();
            access.Complete();

            RoomType = new ObservableCollection<string>() {"Birth Room", "Maternity Room", "Rest Room"};
            Appointment.StartTime = DateTime.Now;
            Appointment.EndTime = DateTime.Now.AddHours(4);
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
                if (DateTime.Compare(Appointment.StartTime, DateTime.Now) < 0)
                {
                    MessageBox.Show("Invalid Date");
                    return;
                }

                else
                {
                    result = ButtonResult.OK;
                    _okButtonPressed = true;
                }
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
