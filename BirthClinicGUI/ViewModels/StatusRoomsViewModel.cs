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
            get => CurrentRestRoom.RoomNumber.ToString();
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
            get => CurrentBirthRoom.RoomNumber.ToString();
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
            get => CurrentMaternityRoom.RoomNumber.ToString();
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
                if (RestRoomIndex < 5)
                {
                    CurrentRestRoom = RestRooms[RestRoomIndex];
                    _dialog.ShowDialog("RestRoomView", new DialogParameters($"Message={CurrentRestRoom.RoomNumber}"), r => { });
                }

                else
                    return;
            }

            else if (roomType == "BirthRooms")
            {
                if (BirthRoomIndex < 15)
                {
                    CurrentBirthRoom = BirthRooms[BirthRoomIndex];
                    _dialog.ShowDialog("BirthRoomView", new DialogParameters($"Message={CurrentBirthRoom.RoomNumber}"), r => { });
                }
                else
                    return;
            }

            else if (roomType == "MaternityRooms")
            {
                if (MaternityIndex < 22)
                {
                    CurrentMaternityRoom = MaternityRooms[MaternityIndex];
                    _dialog.ShowDialog("MaternityRoomView", new DialogParameters($"Message={CurrentMaternityRoom.RoomNumber}"), r => { });
                }

                else
                    return;
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
