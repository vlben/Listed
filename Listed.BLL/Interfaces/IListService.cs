using Listed.BLL.Classes;
using Listed.BLL.DTOs;

namespace Listed.BLL.Interfaces
{
    public interface IListService
    {
        List<List> GetListItems();
        ListOverview GetListItemById(int listItemId);
        public void DeleteListItem(int listItemId);
        public void UpdateListItem(int listItemId, UpdateListItemDTO updateListItemDTO);
		public int GetListItemEpisodes(int listItemId);
	}
}