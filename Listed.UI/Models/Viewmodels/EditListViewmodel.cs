using Listed.BLL.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Listed.UI.Models.Viewmodels
{
	public class EditListVewmodel
	{
		public int ListItemId { get; }
		public string AnimeName { get; }
		public int? EpisodesWatched { get; set; }
		public int? UserRating { get; set; }
		public string Status { get; set; } = string.Empty;
		public int MAX_EPISODES { get; }

		public EditListVewmodel(ListOverview listOverview, int MAX_EPISODES)
		{
			ListItemId = listOverview.ListItemId; 
			AnimeName = listOverview.AnimeName;
			Status = listOverview.Status;
			UserRating = listOverview.UserRating;
			EpisodesWatched = listOverview.EpisodesWatched;
			this.MAX_EPISODES = MAX_EPISODES;
		}
	}
}
