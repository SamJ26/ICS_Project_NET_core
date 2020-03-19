using System.Collections.Generic;

namespace FilmManagment.DAL.Entities
{
    // TODO: add option to choose users defined graphic settings such as colours etc.

    /// <summary>
    /// This class contains informations about users of application 
    /// </summary>
    public class UserEntity : Person
    {
        public string NickName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // TODO: add EC
    }
}
