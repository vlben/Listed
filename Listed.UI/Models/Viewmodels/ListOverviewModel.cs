using Listed.BLL.Classes;

namespace Listed.UI.Models.Viewmodels
{
	public class ListOverviewModel
	{
		public int ListItemId { get; set; }
		public byte[] AnimeCoverArt { get; set; } = Array.Empty<byte>();
		public string AnimeName { get; set; } = string.Empty;
		public int? EpisodesWatched { get; set; }
		public int AnimeEpisodes { get; set; }
		public int? UserRating { get; set; }
		public string Status { get; set; } = string.Empty;

		public ListOverviewModel(ListOverview listOverview)
		{
			ListItemId = listOverview.ListItemId;
			AnimeCoverArt = listOverview.AnimeCoverArt;
			AnimeName = listOverview.AnimeName;
			EpisodesWatched = listOverview.EpisodesWatched;
			AnimeEpisodes = listOverview.AnimeEpisodes;
			UserRating = listOverview.UserRating;
			Status = listOverview.Status;
		}
	}
}
