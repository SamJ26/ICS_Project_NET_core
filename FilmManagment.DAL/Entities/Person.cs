
namespace Project_filmManagment.DAL.Entities
{
    /// <summary>
    /// This is the base class for subclasses Director, Actor and User which inherit from this one
    /// </summary>
    public abstract class Person : EntityBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
    }
}
