using Listed.BLL.Classes;
using Listed.BLL.DTOs;

namespace Listed.BLL.Interfaces
{
	public interface IListService
	{
		List<List> GetListItems();
		List<ListOverview> GetListItemsById(int listItemId);
		public void DeleteListItem(int listItemId);
		public void UpdateListItem(int listItemId, UpdateListItemDTO updateListItemDTO);
	}
}