
namespace Project_filmManagment.DAL.Entities
{
    // TODO: add option to choose users defined graphic settings such as colours etc.

    /// <summary>
    /// This class contains informations about users of application 
    /// </summary>
    public class UserEntity : Person
    {
        // Auto properties
        public string NickName { get; set; }
        public string Password { get; set; }

        // Default constructor
        // For changing default value null in string to string.Empty
        public UserEntity()
        {
            NickName = string.Empty;
            Password = string.Empty;
        }
    }
}
