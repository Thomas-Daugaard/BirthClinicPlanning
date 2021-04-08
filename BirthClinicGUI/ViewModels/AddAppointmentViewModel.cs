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
        public int CurrentAppointmentID { get; set; }
        private bool _okButtonPressed;
        private IDialogService _dialog;
        private IDataAccessActions access = new DataAccessActions(new Context());

        public AddAppointmentViewModel(IDialogService dialog)
        {
            _dialog = dialog;
        }

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
        { }

        #region Helper methods
        public void AddAppointmentToRestRoom()
        {
            RestRoom roomToInsert = null;
            ObservableCollection<RestRoom> restRoomsToCheck =
                access.RestRooms.GetAllRestRoomsWithSpecificNumber(Appointment.Room.RoomNumber);

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
                roomToInsert = room;
            }

            if (roomToInsert == null)
            {
                roomToInsert = new RestRoom() {Appointments = new ObservableCollection<Appointment>()};
            }

            roomToInsert.Appointments.Add(Appointment);
            access.RestRooms.AddRestRoom(roomToInsert);
            access.Complete();
        }
        public void AddAppointmentToBirthRoom()
        {
            BirthRoom roomToInsert = null;
            ObservableCollection<BirthRoom> birthRoomsToCheck =
                access.BirthRooms.GetAllBirthRoomsWithSpecificNumber(Appointment.Room.RoomNumber);

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
                roomToInsert = room;
            }

            if (roomToInsert == null)
            {
                roomToInsert = new BirthRoom() { Appointments = new ObservableCollection<Appointment>() };
            }

            roomToInsert.Appointments.Add(Appointment);
            access.BirthRooms.AddBirthRoom(roomToInsert);
            access.Complete();
        }
        public void AddAppointmentToMaternityRoom()
        {
            MaternityRoom roomToInsert = null;
            ObservableCollection<MaternityRoom> maternityRoomsToCheck =
                access.MaternityRooms.GetAllMaternityRoomsWithSpecificNumber(Appointment.Room.RoomNumber);

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
                roomToInsert = room;
            }

            if (roomToInsert == null)
            {
                roomToInsert = new MaternityRoom() { Appointments = new ObservableCollection<Appointment>() };
            }

            _dialog.ShowDialog("BabyInformationView");

            Appointment.Room.Child = ((App) Application.Current).Child;

            Appointment.RoomID = roomToInsert.RoomID;
            Appointment.Room = roomToInsert;
            access.Appointments.AddAppointment(Appointment);
            access.Complete();

            roomToInsert.Appointments.Add(Appointment);
            access.MaternityRooms.AddMaternity(roomToInsert);
            access.Complete();
        }
        #endregion

        public void OnDialogOpened(IDialogParameters parameters)
        {
            CanClose = true;
            Appointment = new Appointment() {AppointmentID = 0, BirthInProgess = false, StartTime = DateTime.Now.Date, Room = new BirthRoom() {Parents = new Parents() {MomCPR = "", DadCPR = ""}, Child = new Child(), Clinicians = new ObservableCollection<Clinician>()}};
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
                    MessageBox.Show("Date/time cannot be earlier than current date/time");
                    return;
                }

                if (Appointment.StartTime > Appointment.EndTime)
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
                MessageBox.Show("Please fill out all required fields", "CPR-error");

            cpr = Appointment.Room.Parents.MomCPR;

            if (!CheckFormat())
            {
                MessageBox.Show("Please input a CPR with 10 digits (mother)", "CPR digits error");
                CanClose = false;
                return;
            }

            if (!CheckDate())
            {
                MessageBox.Show("Please input a CPR with a valid date (mother)", "CPR date error");
                CanClose = false;
                return;
            }

            if (!Check11Test())
            {
                MessageBox.Show("Please input a valid CPR (mother)", "CPR-invalid error");
                CanClose = false;
                return;
            }

            if (Appointment.Room.Parents.DadCPR != "")
            {
                cpr = Appointment.Room.Parents.DadCPR;

                if (!CheckFormat())
                {
                    MessageBox.Show("Please input a CPR with 10 digits (father)", "CPR digits error");
                    CanClose = false;
                    return;
                }

                if (!CheckDate())
                {
                    MessageBox.Show("Please input a CPR with a valid date (father)", "CPR date error");
                    CanClose = false;
                    return;
                }

                if (!Check11Test())
                {
                    MessageBox.Show("Please input a valid CPR (father)", "CPR-invalid error");
                    CanClose = false;
                    return;
                }

            }

            if (CanClose)
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

        public bool CheckFormat()
        {
            if (cpr.Length == 10)
                return true;

            return false;
        }

        public bool CheckDate()
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

        private bool Check11Test()
        {
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
