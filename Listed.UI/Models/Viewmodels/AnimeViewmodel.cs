using Listed.BLL.Classes;

namespace Listed.UI.Models.Viewmodels
{
	public class AnimeViewmodel
	{
		public int AnimeId { get; }
		public byte[] AnimeCoverArt { get; }

		public AnimeViewmodel(Anime anime)
		{
			AnimeId = anime.AnimeId;
			AnimeCoverArt = anime.AnimeCoverArt;
		}
	}
}
