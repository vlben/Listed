using Listed.BLL.Classes;

namespace Listed.UI.Models.Viewmodels
{
	public class AnimeOverviewModel
	{
		public int AnimeId { get; }
		public string AnimeName { get; } = string.Empty;
		public int StudioId { get; }
		public string StudioName { get; } = string.Empty;
		public int AnimeEpisodes { get; }
		public byte[] AnimeCoverArt { get; }

		public AnimeOverviewModel(AnimeOverview animeOverview)
		{
			AnimeId = animeOverview.AnimeId;
			AnimeName = animeOverview.AnimeName;
			StudioId = animeOverview.StudioId;
			StudioName = animeOverview.StudioName;
			AnimeEpisodes = animeOverview.AnimeEpisodes;
			AnimeCoverArt = animeOverview.AnimeCoverArt;
		}
	}
}
