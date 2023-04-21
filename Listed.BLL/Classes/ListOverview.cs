using Listed.BLL.DTOs;

namespace Listed.BLL.Classes
{
	public class ListOverview
	{
		private readonly int listItemId;

		public int ListItemId
		{
			get { return listItemId; }
		}


		private readonly byte[] animeCoverArt;

		public byte[] AnimeCoverArt
		{
			get { return animeCoverArt; }
		}

		private readonly string animeName;

		public string AnimeName
		{
			get { return animeName; }
		}

		private readonly int? episodesWatched;

		public int? EpisodesWatched
		{
			get { return episodesWatched; }
		}

		private readonly int animeEpisodes;

		public int AnimeEpisodes
		{
			get { return animeEpisodes; }
		}

		private readonly int? userRating;

		public int? UserRating
		{
			get { return userRating; }
		}

		private readonly string status;

		public string Status
		{
			get { return status; }
		}

		private enum ItemStatus
		{
			AddedToList = 0,
			Watching = 1,
			Completed = 2
		}

		public ListOverview(ListOverviewDTO listOverviewDTO)
		{
			this.listItemId = listOverviewDTO.ListItemId;
			this.animeCoverArt = listOverviewDTO.AnimeCoverArt;
			this.animeName = listOverviewDTO.AnimeName;
			this.episodesWatched = listOverviewDTO.EpisodesWatched;
			this.animeEpisodes = listOverviewDTO.AnimeEpisodes;
			this.userRating = listOverviewDTO.UserRating;
			this.status = listOverviewDTO.Status;
		}
	}
}