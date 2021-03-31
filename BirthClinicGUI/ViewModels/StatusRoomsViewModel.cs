using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BirthClinicGUI.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    public class StatusRoomsViewModel : BindableBase, IDialogAware
    {
        private IDialogService _dialog;
        public StatusRoomsViewModel()
        {
        }

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
            RestRooms = new ObservableCollection<RestRoom>()
            {
                new RestRoom()
                {
                    RoomID = 1,
                    Child = new Child()
                    {
                        BirthDate = DateTime.Parse("28/03/2018"),
                        FirstName = "Lukas",
                        LastName = "Meldgaard",
                        Length = 56,
                        Weight = 3590

                    },

                    Parents = new Parents()
                    {
                        DadCPR = "250485-1234",
                        MomCPR = "010186-1234",
                        MomFirstName = "Jennifer",
                        MomLastName = "Meldgaard",
                        DadFirstName = "Thomas",
                        DadLastName = "Daugaard"
                    },

                    Occupied = true
                }
            };
            MaternityIndex = 0;
            RestRoomIndex = 0;
            CurrentRestRoom = RestRooms[RestRoomIndex];

            MaternityRooms = new ObservableCollection<MaternityRoom>()
            {
                new MaternityRoom()
                {
                    RoomID = 1,
                    Child = new Child()
                    {
                        BirthDate = DateTime.Parse("28/03/2018"),
                        FirstName = "Lukas",
                        LastName = "Meldgaard",
                        Length = 56,
                        Weight = 3590

                    },

                    Parents = new Parents()
                    {
                        DadCPR = "250485-1234",
                        MomCPR = "010186-1234",
                        MomFirstName = "Jennifer",
                        MomLastName = "Meldgaard",
                        DadFirstName = "Thomas",
                        DadLastName = "Daugaard"
                    },

                    Occupied = true
                }
            };
            MaternityIndex = 0;
            MaternityIndex = 0;
            CurrentMaternityRoom = MaternityRooms[MaternityIndex];
        }

        private ICommand _restRoomCommand;

        public ICommand RestRoomCommand
        {
            get
            {
                return _restRoomCommand ?? (_restRoomCommand = new DelegateCommand(RestRoomCommandExecute));
            }
        }

        private void RestRoomCommandExecute()
        {
        }

        private ICommand _maternityRoomCommand;

        public ICommand MaternityRoomCommand
        {
            get
            {
                return _restRoomCommand ?? (_restRoomCommand = new DelegateCommand(MaternityRoomCommandExecute));
            }
        }

        private void MaternityRoomCommandExecute()
        {
            
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;

        private ObservableCollection<RestRoom> _restrooms;

        public ObservableCollection<RestRoom> RestRooms
        {
            get => _restrooms;
            set => SetProperty(ref _restrooms, value);
        }

        public RestRoom CurrentRestRoom { get; set; }

        private ObservableCollection<MaternityRoom> _maternityrooms;

        public ObservableCollection<MaternityRoom> MaternityRooms
        {
            get => _maternityrooms;
            set => SetProperty(ref _maternityrooms, value);
        }
        public MaternityRoom CurrentMaternityRoom { get; set; }

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
                _dialog.ShowDialog("RestRoomView", r => { });
            }

            else if (roomType == "MaternityRooms")
            {
                CurrentMaternityRoom = MaternityRooms[MaternityIndex];
                _dialog.ShowDialog("MaternityRoomView", r => { });
            }
        }

        private int _restRoomIndex;

        public int RestRoomIndex
        {
            get => _restRoomIndex;
            set => _restRoomIndex = value;
        }

        private int _maternityRoomIndex;

        public int MaternityIndex
        {
            get => _maternityRoomIndex;
            set => _maternityRoomIndex = value;
        }
    }
}
