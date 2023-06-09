using Listed.BLL.DTOs;
using Listed.BLL.Interfaces;

namespace Listed.Tests.Classes
{
	internal class ListTestDAL : IList
	{
		ListOverviewDTO listOverviewDTO = new()
		{
			ListItemId = 1,
			EpisodesWatched = 10,
			UserRating = 10,
			Status = "completed"
		};

		public void DeleteListItem(int listItemId)
		{
			throw new NotImplementedException();
		}

		public ListOverviewDTO GetListItemById(int listItemId)
		{
			return listOverviewDTO;
		}

		public int GetListItemEpisodes(int listItemId)
		{
			return 10;
		}

		public List<ListDTO> GetListItems()
		{
			throw new NotImplementedException();
		}

		public void UpdateListItem(int listItemId, UpdateListItemDTO updateListItemDTO)
		{
			listOverviewDTO.EpisodesWatched = updateListItemDTO.AnimeEpisodes;
			listOverviewDTO.UserRating = updateListItemDTO.AnimeRating;
			listOverviewDTO.Status = updateListItemDTO.AnimeStatus;
		}
	}
}
