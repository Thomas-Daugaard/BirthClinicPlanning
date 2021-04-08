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
    public class StatusRoomsViewModel : BindableBase, IDialogAware
    {
        //public ObservableCollection<RestRoom> AllRestRooms { get; set; }

        //private ObservableCollection<BirthRoom> _allBirthRooms;

        //public ObservableCollection<BirthRoom> AllBirthRooms
        //{
        //    get=>_allBirthRooms; 
        //    set=>SetProperty(ref _allBirthRooms, value);
        //}
        //fpublic ObservableCollection<MaternityRoom> AllMaternityRooms { get; set; }
        private IDataAccessActions access = new DataAccessActions(new Context());
        private IDialogService _dialog;

        public StatusRoomsViewModel(IDialogService dialog)
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
            RestRooms = new ObservableCollection<RestRoom>();
            RestRooms = access.RestRooms.GetAllRestRoom();

            BirthRooms = new ObservableCollection<BirthRoom>();
            BirthRooms = access.BirthRooms.GetAllBirthsRooms();

            MaternityRooms = new ObservableCollection<MaternityRoom>();
            MaternityRooms = access.MaternityRooms.GetAllMaternityRooms();
        }

        private string title = "StatusRoomsViewModel";

        public string Title
        {
            get=>title;
            set => SetProperty(ref title, value);
        }
        public event Action<IDialogResult> RequestClose;

        #region Rooms collections + CurrentRoom properties

        private ObservableCollection<RestRoom> _restrooms;  //Restroom

        public ObservableCollection<RestRoom> RestRooms
        {
            get => _restrooms;
            set => SetProperty(ref _restrooms, value);
        }

        private RestRoom _currentRestRoom;

        public RestRoom CurrentRestRoom
        {
            get=>_currentRestRoom; 
            set=>SetProperty(ref _currentRestRoom, value);
        }

        public string CurrentRestRoomId
        {
            get => CurrentRestRoom.RoomID.ToString();
        }


        private ObservableCollection<BirthRoom> _birthRooms;  //Birthroom
        public ObservableCollection<BirthRoom> BirthRooms
        {
            get => _birthRooms;
            set => SetProperty(ref _birthRooms, value);
        }
        public BirthRoom CurrentBirthRoom { get; set; }


        private ObservableCollection<MaternityRoom> _maternityrooms; //MaternityRoom

        public ObservableCollection<MaternityRoom> MaternityRooms
        {
            get => _maternityrooms;
            set => SetProperty(ref _maternityrooms, value);
        }

        public MaternityRoom CurrentMaternityRoom { get; set; }
        #endregion

        #region Select Room Command
        private DelegateCommand<string> _selectRoomCommand;

        public DelegateCommand<string> SelectRoomCommand
        {
            get
            {
                return _selectRoomCommand ?? (_selectRoomCommand = new DelegateCommand<string>(SelectRoomCommandExecute));
            }
        }

        private void SelectRoomCommandExecute(string roomType)
        {
            if (roomType == "RestRooms")
            {
                CurrentRestRoom = RestRooms[RestRoomIndex]; 

                if (CurrentRestRoom != null)
                {
                    _dialog.ShowDialog("RestRoomView",new DialogParameters($"Message={CurrentRestRoom.RoomID}"), r=>{ });
                }
                else
                {
                    MessageBox.Show("CurrentRestRoom == null / Not set");
                    return;
                }
            }
            //
            else if (roomType == "BirthRooms")
            {
                CurrentBirthRoom = BirthRooms[BirthRoomIndex];
                _dialog.ShowDialog("BirthRoomView", r => { });
            }

            else if (roomType == "MaternityRooms")
            {
                CurrentMaternityRoom = MaternityRooms[MaternityIndex];
                _dialog.ShowDialog("MaternityRoomView", r => { });
            }
        }
        #endregion

        #region Room indexes
        private int _restRoomIndex;

        public int RestRoomIndex
        {
            get => _restRoomIndex;
            set => _restRoomIndex = value;
        }


        private int _birthRoomIndex;
        public int BirthRoomIndex
        {
            get => _birthRoomIndex;
            set => _birthRoomIndex = value;
        }

        private int _maternityRoomIndex;
        public int MaternityIndex
        {
            get => _maternityRoomIndex;
            set => _maternityRoomIndex = value;
        }


        #endregion

    }
}
