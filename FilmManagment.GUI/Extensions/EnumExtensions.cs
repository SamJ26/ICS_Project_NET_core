using System;
using System.Collections.Generic;

namespace FilmManagment.GUI.Extensions
{
    public static class EnumExtensions
    {
        public static List<string> ConvertEnumToList<EnumType>() where EnumType : System.Enum
        {
            var listOfNames = new List<string>();
            var values = Enum.GetValues(typeof(EnumType));
            foreach (int item in values)
            {
                string nameOfItem = Enum.GetName(typeof(EnumType), item);
                listOfNames.Add(nameOfItem);
            }
            return listOfNames;
        }
    }
}
