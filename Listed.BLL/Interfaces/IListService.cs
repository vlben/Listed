using Listed.BLL.Classes;

namespace Listed.BLL.Interfaces
{
    public interface IListService
    {
        List<List> GetListItems();
        List<ListOverview> GetListItemsById(int listItemId);
        public void DeleteListItem(int listItemId);
    }
}