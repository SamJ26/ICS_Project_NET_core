using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    // TODO: add option to choose users defined graphic settings such as colours etc.

    /// <summary>
    /// This class contains informations about users of application 
    /// </summary>
    internal class User : Person
    {
        // Private fields of the class
        string nickName;
        string password;
        
        // Default constructor
        // For changing default value null in string to string.Empty
        public User()
        {
            nickName = string.Empty;
            password = string.Empty;
        }

        #region Properties

        // Methods for getting and setting the value of variable nickName
        public string NickName
        {
            get => nickName;
            set => nickName = value;
        }

        // Methods for getting and setting the value of variable password
        public string Password
        {
            get => password; 
            set => password = value; 
        }

        #endregion

    }
}
