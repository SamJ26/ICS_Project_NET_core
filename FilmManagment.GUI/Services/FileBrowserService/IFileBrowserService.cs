using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.GUI.Services.FileBrowserService
{
    public interface IFileBrowserService
    {
        string OpenFileDialog(string defaultPath);
    }
}
