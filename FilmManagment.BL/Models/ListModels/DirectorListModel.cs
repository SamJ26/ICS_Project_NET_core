using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.BL.Models.ListModels
{
    public class DirectorListModel : ModelBase
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        private sealed class FirstNameSecondNameEqualityComparer : IEqualityComparer<DirectorListModel>
        {
	        public bool Equals(DirectorListModel x, DirectorListModel y)
	        {
		        if (ReferenceEquals(x, y)) return true;
		        if (ReferenceEquals(x, null)) return false;
		        if (ReferenceEquals(y, null)) return false;
		        if (x.GetType() != y.GetType()) return false;
		        return x.Id == y.Id
		               && x.FirstName == y.FirstName
		               && x.SecondName == y.SecondName;
	        }

	        public int GetHashCode(DirectorListModel obj)
	        {
		        return HashCode.Combine(obj.FirstName, obj.SecondName);
	        }
        }

        public static IEqualityComparer<DirectorListModel> FirstNameSecondNameComparer { get; } = new FirstNameSecondNameEqualityComparer();
    }
}
