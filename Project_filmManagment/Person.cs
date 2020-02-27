using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{

    // TODO: add new class Actor and class Director and use heritage for them

    /// <summary>
    /// This class contains all informations about actors and directors
    /// For every new person, new object from this class need to be created
    /// Both actors and directors have the same class because of simplicity in database mapping
    /// </summary>
    abstract class Person
    {
        // Private fields of the class ( they are private by default )
        string firstName;
        string secondName;
        int age;

        // TODO: Photography ????
       

        // Default constructor which sets the values to properties when new object is created
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
            get =>secondName; 
            set =>secondName = value; 
        }

        // Methods for getting and setting the value of variable age
        public int Age
        {
            get =>age; 
            set =>age = value; 
        }

        #endregion

    }
}
