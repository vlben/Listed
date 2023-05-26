using Listed.BLL.DTOs;

namespace Listed.BLL.Interfaces
{
	public interface IAnime
	{
		List<AnimeDTO> GetAllAnimes();
		AnimeOverviewDTO GetAnimeById(int animeId);
		public void AddAnimeToList(int animeId);
		public bool AnimeExistsInList(int animeId);
	}
}
