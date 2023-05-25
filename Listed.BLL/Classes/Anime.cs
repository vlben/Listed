using Listed.BLL.DTOs;

namespace Listed.BLL.Classes
{
	public class Anime
	{
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

		public Anime(AnimeDTO animeDTO)
		{
			if (animeDTO == null)
			{
				throw new NullReferenceException("AnimeDTO needs to be filled");
			}

			this.animeId = animeDTO.AnimeId;
			this.animeCoverArt = animeDTO.AnimeCoverArt;
		}
	}
}
