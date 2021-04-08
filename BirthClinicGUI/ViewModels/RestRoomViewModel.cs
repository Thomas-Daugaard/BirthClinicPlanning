using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB;
using BirthClinicPlanningDB.DomainObjects;
using Itenso.TimePeriod;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class RestRoomViewModel : BindableBase, IDialogAware
    {
        private IDataAccessActions access = new DataAccessActions(new Context());
        private IDialogService _dialog;

        private RestRoom _currentRestRoom;
        public RestRoom CurrentRestRoom { 
            get=> _currentRestRoom; 
            set=>SetProperty(ref _currentRestRoom,value); }

        private ObservableCollection<Appointment> _appointmentsForRoom = new ObservableCollection<Appointment>();

        public ObservableCollection<Appointment> AppointmentsForRoom
        {
            get => _appointmentsForRoom;
            set => SetProperty(ref _appointmentsForRoom, value);
        }

        private Parents _parents;

        public Parents Parents
        {
            get => _parents;
            set => SetProperty(ref _parents, value);
        }
        public RestRoomViewModel(IDialogService dialog)
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
            int roomid = int.Parse(parameters.GetValue<string>("Message"));

            CurrentRestRoom = access.RestRooms.GetSingleRestRoom(roomid);

            AppointmentsForRoom = CurrentRestRoom.Appointments;

            foreach (var item in AppointmentsForRoom)
            {
                DateTime currentTime = DateTime.Now;
                TimeRange appointmentrange = new TimeRange(item.StartTime, item.EndTime);
                TimeRange nowrange = new TimeRange(currentTime, currentTime);

                if (appointmentrange.IntersectsWith(nowrange))
                {
                    CurrentRestRoom.Occupied = true;
                    Parents = CurrentRestRoom.Parents;
                }
                else
                {
                    CurrentRestRoom.Occupied = false;
                }
            }

            access.Complete();
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;
    }
}
