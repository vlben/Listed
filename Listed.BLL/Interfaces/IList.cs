using Listed.BLL.DTOs;

namespace Listed.BLL.Interfaces
{
    public interface IList
    {
        List<ListDTO> GetListItems();
        ListOverviewDTO GetListItemById(int listItemId);
        public void DeleteListItem(int listItemId);
        public void UpdateListItem(int listItemId, UpdateListItemDTO updateListItemDTO);
        public int GetListItemEpisodes(int listItemId);
    }
}
