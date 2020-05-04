using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.GUI.Services.WarningMessageService
{
    public interface IWarningService
    {
        void ShowWarning(Type messageType);
    }
}
