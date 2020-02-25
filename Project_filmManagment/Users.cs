using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{

    // TODO: add heritage from class Person

    class Users
    {
        // Private fields of the class
        string nickName;
        string password;
        
        // Default constructor
        public Users()
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
