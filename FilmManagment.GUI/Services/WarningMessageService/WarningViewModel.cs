using FilmManagment.GUI.Commands;
using FilmManagment.GUI.ViewModels;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Wrappers;
using System.Windows.Input;

namespace FilmManagment.GUI.Services.WarningMessageService
{
    public class WarningViewModel : ViewModelBase, IWarningViewModel
    {
        private IMediator usedMediator;

        public WarningViewModel(IMediator mediator)
        {
            usedMediator = mediator;

            YesButtonCommand = new RelayCommand(OnYesButtonCommandExecute);
            NoButtonCommand = new RelayCommand(OnNoButtonCommandExecute);
        }

        public ICommand YesButtonCommand { get; }
        public ICommand NoButtonCommand { get; }

        private void OnYesButtonCommandExecute(object parameter) => usedMediator.Send(new YES_WarningResultMessage<FilmWrappedModel>());

        private void OnNoButtonCommandExecute(object parameter) => usedMediator.Send(new NO_WarningResultMessage<FilmWrappedModel>());

        public void CloseWindow()
        {

        }
    }
}
