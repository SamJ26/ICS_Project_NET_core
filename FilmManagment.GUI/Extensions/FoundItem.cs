using FilmManagment.DAL.Enums;
using System;

namespace FilmManagment.GUI.Extensions
{
    public class FoundItem
    {
        public Guid Id { get; set; }
        public string FirstNameOrOriginalName { get; set; } = string.Empty;
        public string SecondNameOrCzechName { get; set; } = string.Empty;
        public FoundObjectType FoundObject { get; set; }
    }
}
