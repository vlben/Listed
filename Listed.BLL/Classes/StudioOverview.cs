using Listed.BLL.DTOs;

namespace Listed.BLL.Classes
{
	public class StudioOverview
	{
		private readonly string studioName;

		public string StudioName
		{
			get { return studioName; }
		}

		private readonly int animeId;

		public int AnimeId
		{
			get { return animeId; }
		}


		private readonly byte[] animeCoverArt;

		public byte[] AnimeCoverArt
		{
			get { return animeCoverArt; }
		}


		public StudioOverview(StudioOverviewDTO studioOverviewDTO)
		{
			if (studioOverviewDTO == null)
			{
				throw new NullReferenceException("StudioOverviewDTO needs to be filled");
			}

			this.studioName = studioOverviewDTO.StudioName;
			this.animeId = studioOverviewDTO.AnimeId;
			this.animeCoverArt = studioOverviewDTO.AnimeCoverArt;
		}
	}
}
