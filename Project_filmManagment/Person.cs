using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    /// <summary>
    /// This is the base class for subclasses Director, Actor and User which inherit from this one
    /// </summary>
    abstract internal class Person
    {
        // Private fields of the class ( they are private by default )
        string firstName;
        string secondName;
        int age;    

        // Default constructor
        public Person()
        {
            firstName = string.Empty;
            secondName = string.Empty;
            age = 0;        
        }

        #region Properties

        // Methods for getting and setting the content of variable firstName
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        // Methods for getting and setting the content of variable secondName
        public string SecondName
        {
            get => secondName; 
            set => secondName = value; 
        }

        // Methods for getting and setting the value of variable age
        public int Age
        {
            get => age; 
            set => age = value; 
        }

        #endregion

    }
}
