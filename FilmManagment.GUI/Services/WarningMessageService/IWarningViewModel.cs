using FilmManagment.GUI.ViewModels.Interfaces;
using System;

namespace FilmManagment.GUI.Services.WarningMessageService
{
    public interface IWarningViewModel : IViewModel
    {
        Type MessageType { get; set; }
    }
}
