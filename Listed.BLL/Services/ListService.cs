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

        public ListOverview GetListItemById(int listItemId)
        {
            ListOverviewDTO listOverviewDTO = new();

            try
            {
                listOverviewDTO = iList.GetListItemById(listItemId);
            }

            catch (Exception exception)
            {
                throw new Exception("Can't add list items to collection", exception);
            }

            return new ListOverview(listOverviewDTO);
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
			int MIN_EPISODES = 0;
			int MAX_EPISODES = GetListItemEpisodes(listItemId);

			int MIN_RATING = 0;
            int MAX_RATING = 10;

            try
            {
                if (!(updateListItemDTO.AnimeEpisodes >= MIN_EPISODES && updateListItemDTO.AnimeEpisodes <= MAX_EPISODES))
                {
                    throw new Exception($"Episodes should be between {MIN_EPISODES} - {MAX_EPISODES}");
                }

				if (!(updateListItemDTO.AnimeRating >= MIN_RATING && updateListItemDTO.AnimeRating <= MAX_RATING))
				{
					throw new Exception($"Rating should be between {MIN_RATING} - {MAX_RATING}");
				}

				iList.UpdateListItem(listItemId, updateListItemDTO);
            }
            catch (Exception exception)
            {

                throw new Exception("Could't update anime", exception);
            }
        }

		public int GetListItemEpisodes(int listItemId)
		{
            int MAX_EPISODES;

			try
			{
				MAX_EPISODES = iList.GetListItemEpisodes(listItemId);
			}
			catch (Exception exception)
			{
				throw new Exception("Couldn't get the amount of episodes for this list item", exception);
			}

            return MAX_EPISODES;
		}
	}
}
