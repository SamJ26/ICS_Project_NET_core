using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FilmManagment.GUI.Extensions
{
	public static class ObservableCollectionExtensions
	{
		public static void AddList<TListModel>(this ObservableCollection<TListModel> collection, IEnumerable<TListModel> items)
		{
			foreach (var item in items)
			{
				collection.Add(item);
			}
		}
	}
}
