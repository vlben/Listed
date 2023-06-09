using Listed.BLL.DTOs;
using Listed.BLL.Interfaces;

namespace Listed.Tests.Classes
{
	internal class AnimeListDAL : IAnime
	{
		AnimeOverviewDTO animeOverviewDTO = new() { AnimeId = 1 };

		public void AddAnimeToList(int animeId)
		{
			animeOverviewDTO.AnimeId = animeId;
		}

		public bool AnimeExistsInList(int animeId)
		{
			if (animeId == animeOverviewDTO.AnimeId)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public List<AnimeDTO> GetAllAnimes()
		{
			throw new NotImplementedException();
		}

		public AnimeOverviewDTO GetAnimeById(int animeId)
		{
			return animeOverviewDTO;
		}
	}
}
