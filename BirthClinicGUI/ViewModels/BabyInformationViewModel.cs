using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BirthClinicPlanningDB.DomainObjects;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class BabyInformationViewModel : BindableBase, IDialogAware
    {
        private bool _okButtonPressed;
        public Child Child { get; set; }
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            ((App) Application.Current).Child = Child;
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Child = ((App) Application.Current).Child;
        }

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

            if (Child.FirstName == "" || Child.LastName == "" || Child.Weight == 0 || Child.Length == 0)
                MessageBox.Show("Please fill out all fields", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            else
                RequestClose(new DialogResult(result));
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;
    }
}
