﻿using System;
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
            RestRooms = ((App)Application.Current).access.RestRooms.GetAllRestRoom();

            BirthRooms = new ObservableCollection<BirthRoom>();
            BirthRooms = ((App)Application.Current).access.BirthRooms.GetAllBirthsRooms();

            MaternityRooms = new ObservableCollection<MaternityRoom>();
            MaternityRooms = ((App)Application.Current).access.MaternityRooms.GetAllMaternityRooms();
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

        public string CurrentBirthRoomId
        {
            get => CurrentBirthRoom.RoomID.ToString();
        }


        private ObservableCollection<MaternityRoom> _maternityrooms; //MaternityRoom

        public ObservableCollection<MaternityRoom> MaternityRooms
        {
            get => _maternityrooms;
            set => SetProperty(ref _maternityrooms, value);
        }

        private MaternityRoom _currentMaternityRoom;

        public MaternityRoom CurrentMaternityRoom
        {
            get => _currentMaternityRoom;
            set => SetProperty(ref _currentMaternityRoom, value);
        }

        public string CurrentMaternityRoomId
        {
            get => CurrentMaternityRoom.RoomID.ToString();
        }
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
            else if (roomType == "BirthRooms")
            {
                CurrentBirthRoom = BirthRooms[BirthRoomIndex];

                if (CurrentBirthRoom != null)
                {
                    _dialog.ShowDialog("BirthRoomView", new DialogParameters($"Message={CurrentBirthRoom.RoomID}"), r => { });
                }
                else
                {
                    MessageBox.Show("CurrentBirthRoom == null / Not set");
                    return;
                }

            }
            else if (roomType == "MaternityRooms")
            {
                CurrentMaternityRoom = MaternityRooms[MaternityIndex];

                if (CurrentMaternityRoom != null)
                {
                    _dialog.ShowDialog("MaternityRoomView", new DialogParameters($"Message={CurrentMaternityRoom.RoomID}"), r => { });
                }
                else
                {
                    MessageBox.Show("CurrentMaternityRoom == null / Not set");
                    return;
                }
                
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
