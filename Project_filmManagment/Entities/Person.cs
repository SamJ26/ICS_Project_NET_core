using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    /// <summary>
    /// This is the base class for subclasses Director, Actor and User which inherit from this one
    /// </summary>
    abstract public class Person
    {
        // Auto properties
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }

        // Default constructor
        public Person()
        {
            FirstName = string.Empty;
            SecondName = string.Empty;
            Age = 0;        
        }
    }
}
