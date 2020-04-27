using FilmManagment.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FilmManagment.GUI.Services.WarningMessageService
{
    public class WarningViewModel : ViewModelBase, IWarningViewModel
    {
        private IMediator usedMediator;

        public WarningViewModel(IMediator mediator)
        {
            usedMediator = mediator;
        }

        public ICommand YesButtonCommand { get; }
        public ICommand NoButtonCommand { get; }

        private void OnYesButtonCommandExecute(object parameter)
        {

        }

        private void OnNoButtonCommandExecute(object parameter)
        {

        }
    }
}
