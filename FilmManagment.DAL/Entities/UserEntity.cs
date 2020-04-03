using System;
using System.Collections.Generic;

namespace FilmManagment.DAL.Entities
{
	// TODO: add option to choose users defined graphic settings such as colours etc.

	/// <summary>
	/// This class contains informations about users of application 
	/// </summary>
	public class UserEntity : PersonBase
	{
		public string NickName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;

		private sealed class UserEntityEqualityComparer : IEqualityComparer<UserEntity>
		{
			public bool Equals(UserEntity x, UserEntity y)
			{
				if (ReferenceEquals(x, y)) return true;
				if (ReferenceEquals(x, null)) return false;
				if (ReferenceEquals(y, null)) return false;
				if (x.GetType() != y.GetType()) return false;
				return x.Id == y.Id
					   && x.FirstName == y.FirstName
					   && x.SecondName == y.SecondName
					   && x.Age == y.Age
					   && x.NickName == y.NickName
					   && x.Password == y.Password;
			}

			public int GetHashCode(UserEntity obj)
			{
				return HashCode.Combine(obj.Id, obj.FirstName, obj.SecondName, obj.Age, obj.NickName, obj.Password);
			}
		}

		public static IEqualityComparer<UserEntity> UserEntityComparer { get; } = new UserEntityEqualityComparer();
	}
}
