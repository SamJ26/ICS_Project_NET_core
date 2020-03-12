using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment.Entities
{
    /// <summary>
    /// This is the base class for subclasses Director, Actor and User which inherit from this one
    /// </summary>
    public abstract class Person : EntityBase
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
