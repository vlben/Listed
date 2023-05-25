using Listed.BLL.DTOs;

namespace Listed.BLL.Classes
{
	public class AnimeOverview
	{
		private readonly int animeId;

		public int AnimeId
		{
			get { return animeId; }
		}

		private readonly string animeName = string.Empty;

		public string AnimeName
		{
			get { return animeName; }
		}

		private readonly int animeEpisodes;

		public int AnimeEpisodes
		{
			get { return animeEpisodes; }
		}

		private byte[] animeCoverArt;

		public byte[] AnimeCoverArt
		{
			get { return animeCoverArt; }
			set { animeCoverArt = value; }
		}

		private readonly int studioId;

		public int StudioId
		{
			get { return studioId; }
		}

		private readonly string studioName;

		public string StudioName
		{
			get { return studioName; }
		}


		public AnimeOverview(AnimeOverviewDTO animeOverviewDTO)
		{
			if (animeOverviewDTO == null)
			{
				throw new NullReferenceException("AnimeOverviewDTO needs to be filled");
			}

			this.animeId = animeOverviewDTO.AnimeId;
			this.animeName = animeOverviewDTO.AnimeName;
			this.animeEpisodes = animeOverviewDTO.AnimeEpisodes;
			this.animeCoverArt = animeOverviewDTO.AnimeCoverArt;
			this.studioName = animeOverviewDTO.StudioName;
			this.studioId = animeOverviewDTO.StudioId;
		}
	}
}
