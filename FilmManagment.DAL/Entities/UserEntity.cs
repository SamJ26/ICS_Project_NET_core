using System.Collections.Generic;

namespace FilmManagment.DAL.Entities
{
    // TODO: add option to choose users defined graphic settings such as colours etc.

    /// <summary>
    /// This class contains informations about users of application 
    /// </summary>
    public class UserEntity : Person
    {
        public string NickName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        private sealed class UsersEqualityComparer : IEqualityComparer<UserEntity>
        {
            public bool Equals(UserEntity x, UserEntity y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return x.Id.Equals(y.Id) &&
                       string.Equals(x.FirstName, y.FirstName) &&
                       string.Equals(x.SecondName, y.SecondName) &&
                       x.Age.Equals(y.Age) &&
                       string.Equals(x.NickName, y.NickName) &&
                       string.Equals(x.Password, y.Password);
            }

            public int GetHashCode(UserEntity obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.FirstName != null ? obj.FirstName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.SecondName != null ? obj.SecondName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Age.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.NickName != null ? obj.NickName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Password != null ? obj.Password.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        // Property which is used to approach methods for testing in class ActorEqualityComparer
        public static IEqualityComparer<UserEntity> RatingEqualityComparer { get; } = new UsersEqualityComparer();
    }
}
