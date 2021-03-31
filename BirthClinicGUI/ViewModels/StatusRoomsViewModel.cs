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
    class StatusRoomsViewModel : BindableBase, IDialogAware
    {
        public enum Types
        {
            RestRoom,
            MaternityRoom
        }

        public Types RoomType { get; set; }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            RoomType = Types.MaternityRoom;

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
            RoomType = Types.RestRoom;
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
            RoomType = Types.MaternityRoom;
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;

        private ObservableCollection<RestRoom> _restrooms;

        public ObservableCollection<RestRoom> RestRooms
        {
            get => _restrooms;
            set => SetProperty(ref _restrooms, value);
        }

        private ObservableCollection<MaternityRoom> _maternityrooms;

        public ObservableCollection<MaternityRoom> MaternityRooms
        {
            get => _maternityrooms;
            set => SetProperty(ref _maternityrooms, value);
        }
    }
}
