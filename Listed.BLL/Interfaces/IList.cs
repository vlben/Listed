using Listed.BLL.DTOs;

namespace Listed.BLL.Interfaces
{
	public interface IList
	{
		List<ListDTO> GetListItems();
		List<ListOverviewDTO> GetListItemsById(int listItemId);
		public void DeleteListItem(int listItemId);
		public void UpdateListItem(int listItemId, UpdateListItemDTO updateListItemDTO);
	}
}
