using Listed.BLL.Classes;
using Listed.BLL.DTOs;
using Listed.BLL.Interfaces;

namespace Listed.BLL.Services
{
	public class ListService : IListService
	{
		readonly IList iList;

		public ListService(IList iList)
		{
			this.iList = iList;
		}

		public List<List> GetListItems()
		{
			List<List> ListItems = new();

			try
			{
				List<ListDTO> listDTOs = iList.GetListItems();
				foreach (ListDTO listDTO in listDTOs)
				{
					ListItems.Add(new List(listDTO));
				}
			}

			catch (Exception exception)
			{
				throw new Exception("Can't add list items to collection", exception);
			}

			return ListItems;
		}

		public List<ListOverview> GetListItemsById(int listItemId)
		{
			List<ListOverview> listItems = new();

			try
			{
				List<ListOverviewDTO> listOverviewDTOs = iList.GetListItemsById(listItemId);
				foreach (ListOverviewDTO listOverviewDTO in listOverviewDTOs)
				{
					listItems.Add(new ListOverview(listOverviewDTO));
				}
			}

			catch (Exception exception)
			{
				throw new Exception("Can't add list items to collection", exception);
			}

			return listItems;
		}

		public void DeleteListItem(int listItemId)
		{
			try
			{
				iList.DeleteListItem(listItemId);
			}
			catch (Exception exception)
			{
				throw new Exception("Could't delete anime from list", exception);
			}

		}

		public void UpdateListItem(int listItemId, UpdateListItemDTO updateListItemDTO)
		{
			try
			{
				iList.UpdateListItem(listItemId, updateListItemDTO);
			}
			catch (Exception exception)
			{

				throw new Exception("Could't update anime", exception);
			}
		}
	}
}
