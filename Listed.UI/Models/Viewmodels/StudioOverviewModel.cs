using Listed.BLL.Classes;

namespace Listed.UI.Models.Viewmodels
{
	public class StudioOverviewModel
	{
		public string StudioName { get; } = string.Empty;
		public int AnimeId { get; }
		public byte[] AnimeCoverArt { get; }

		public StudioOverviewModel(StudioOverview studioOverview)
		{
			StudioName = studioOverview.StudioName;
			AnimeId = studioOverview.AnimeId;
			AnimeCoverArt = studioOverview.AnimeCoverArt;
		}
	}
}
