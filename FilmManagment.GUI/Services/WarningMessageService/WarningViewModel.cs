using FilmManagment.GUI.Commands;
using FilmManagment.GUI.ViewModels;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Wrappers;
using System.Windows.Input;
using System;

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

        private Type messageType;
        public Type MessageType
        {
            get => messageType;
            set => messageType = value;
        }

        private void OnYesButtonCommandExecute(object parameter) => usedMediator.Send(Get_YES_TypeOfMessage());

        private void OnNoButtonCommandExecute(object parameter) => usedMediator.Send(Get_NO_TypeOfMessage());

        private dynamic Get_YES_TypeOfMessage()
        {
            if (MessageType == null)
            {
                throw new ArgumentNullException("Message type can not be null!");
            }

            if (MessageType == typeof(FilmWrappedModel))
                return new YES_WarningResultMessage<FilmWrappedModel>();

            else if (MessageType == typeof(ActorWrappedModel))
                return new YES_WarningResultMessage<ActorWrappedModel>();

            else if (MessageType == typeof(DirectorWrappedModel))
                return new YES_WarningResultMessage<DirectorWrappedModel>();

            else
                throw new ArgumentException("Invalid message type!");
        }

        private dynamic Get_NO_TypeOfMessage()
        {
            if (MessageType == null)
            {
                throw new ArgumentNullException("Message type can not be null!");
            }

            if (MessageType == typeof(FilmWrappedModel))
                return new NO_WarningResultMessage<FilmWrappedModel>();

            else if (MessageType == typeof(ActorWrappedModel))
                return new NO_WarningResultMessage<ActorWrappedModel>();

            else if (MessageType == typeof(DirectorWrappedModel))
                return new NO_WarningResultMessage<DirectorWrappedModel>();

            else
                throw new ArgumentException("Invalid message type!");
        }
    }
}
