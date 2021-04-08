using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public bool CanClose { get; set; }

        private bool _okButtonPressed;

        private IDataAccessActions access = new DataAccessActions(new Context());

        public bool CanCloseDialog()
        {
            return true;
        }

        public bool ValidateDate(Appointment a1, Appointment a2)
        {
            TimeRange AppointmentToInsert = new TimeRange(a1.StartTime, a1.EndTime);
            TimeRange AppointmentToCompare = new TimeRange(a2.StartTime, a2.EndTime);

            if (AppointmentToCompare.IsSamePeriod(AppointmentToInsert))
            {
                MessageBox.Show("TimeRange is occupied");
                return AppointmentToCompare.IsSamePeriod(AppointmentToInsert);
            }
            else if (AppointmentToCompare.HasInside(AppointmentToInsert))
            {
                MessageBox.Show("TimeRange overlaps another Timerange");
                return AppointmentToCompare.HasInside(AppointmentToInsert);
            }
            else if (AppointmentToCompare.OverlapsWith(AppointmentToInsert))
            {
                MessageBox.Show("TimeRange overlaps another Timerange");
                return AppointmentToCompare.OverlapsWith(AppointmentToInsert);
            }
            else if (AppointmentToCompare.IntersectsWith(AppointmentToInsert))
            {
                MessageBox.Show("Timerange intersects with another Timerange");
                return AppointmentToCompare.IntersectsWith(AppointmentToInsert);
            }

            else
                return false;
        }

        public void OnDialogClosed()
        {
            
        }

        #region Helper methods
        public void AddAppointmentToRestRoom()
        {
            Room roomToCopy = Appointment.Room;
            ObservableCollection<RestRoom> restRoomsToCheck = access.RestRooms.GetAllRestRoom();
            access.Complete();

            foreach (var room in restRoomsToCheck)
            {
                if (room.Appointments != null)
                {
                    foreach (var appointment in room.Appointments)
                    {
                        if (ValidateDate(Appointment, appointment))
                        {
                            CanClose = false;
                            return;
                        }
                    }
                }
                Appointment.Room = room;
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
        public void AddAppointmentToBirthRoom()
        {
            Room roomToCopy = Appointment.Room;
            ObservableCollection<BirthRoom> birthRoomsToCheck = access.BirthRooms.GetAllBirthsRooms();
            access.Complete();

            foreach (var room in birthRoomsToCheck)
            {
                if (room.Appointments != null)
                {
                    foreach (var appointment in room.Appointments)
                    {
                        if (ValidateDate(Appointment, appointment))
                        {
                            CanClose = false;
                            return;
                        }
                    }
                }
                Appointment.Room = room;
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
        public void AddAppointmentToMaternityRoom()
        {
            Room roomToCopy = Appointment.Room;
            ObservableCollection<MaternityRoom> maternityRoomsToCheck = access.MaternityRooms.GetAllMaternityRooms();
            access.Complete();

            foreach (var room in maternityRoomsToCheck)
            {
                if (room.Appointments != null)
                {
                    foreach (var appointment in room.Appointments)
                    {
                        if (ValidateDate(Appointment, appointment))
                        {
                            CanClose = false;
                            return;
                        }
                    }
                }
                Appointment.Room = room;
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
        #endregion

        public void OnDialogOpened(IDialogParameters parameters)
        {
            CanClose = true;
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
            CanClose = true;
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
            {
                if (DateTime.Compare(Appointment.StartTime, DateTime.Now) < 0)
                {
                    CanClose = false;
                    MessageBox.Show("Invalid Date");
                    return;
                }

                else if (Appointment.StartTime > Appointment.EndTime)
                {
                    CanClose = false;
                    MessageBox.Show("Start date/time cannot be greater than end date/time");
                }

                else
                {
                    switch (RoomType[RoomTypeIndex])
                    {
                        case "Rest Room":
                            AddAppointmentToRestRoom();
                            break;

                        case "Birth Room":
                            AddAppointmentToBirthRoom();
                            break;

                        case "Maternity Room":
                            AddAppointmentToMaternityRoom();
                            break;
                    }
                }

                if (CanClose)
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

            if (!CheckFormat(Appointment.Room.Parents.MomCPR) || !CheckFormat(Appointment.Room.Parents.DadCPR))
            {
                MessageBox.Show("Venligst angiv 10 tegn", "Ugyldigt antal tegn", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!CheckDate(Appointment.Room.Parents.MomCPR) || !CheckFormat(Appointment.Room.Parents.DadCPR))
            {
                MessageBox.Show("Venligst angiv en gyldig dato", "Ugyldig dato", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Check11Test(Appointment.Room.Parents.MomCPR) || !CheckFormat(Appointment.Room.Parents.DadCPR))
            {
                MessageBox.Show("Venligst angiv et gyldigt CPR-nummer", "Ugyldigt CPR-nummer", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            else if (CanClose)
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

        #region CPR-validation

        public bool CheckFormat(string cpr)
        {
            Cpr = cpr;

            if (cpr.Length == 10)
                return true;

            return false;
        }

        public bool CheckDate(string cpr)
        {
            string daystring = cpr.Substring(0, 2);
            string monthstring = cpr.Substring(2, 2);
            string yearstring = cpr.Substring(4, 2);

            int day = int.Parse(daystring);
            int month = int.Parse(monthstring);
            int tempyear = int.Parse(yearstring);
            int year = (tempyear >= 0 && tempyear <= 20 ? 2000 + tempyear : 1900 + tempyear);

            try
            {
                DateTime date = new DateTime(year, month, day);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private bool Check11Test(string cpr)
        {
            Cpr = cpr;

            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += int.Parse(cpr.Substring(i, 1)) * (4 - i);
            }

            for (int i = 3; i < 10; i++)
            {
                sum += int.Parse(cpr.Substring(i, 1)) * (10 - i);
            }

            if (sum % 11 != 0)
                return false;

            return true;
        }


        private string cpr;

        public string Cpr
        {
            get => (cpr.Substring(0, 6) + "-" + cpr.Substring(7, 4));
            set
            {
                if (cpr == value.Replace("-", string.Empty))
                    return;

                cpr = value.Replace("-", string.Empty).Replace("/", string.Empty).Replace(" ", string.Empty);
            }
        }

        #endregion
    }
}
