using Listed.BLL.Classes;
using Listed.BLL.DTOs;
using Listed.BLL.Interfaces;

namespace Listed.BLL.Services
{
	public class AnimeService : IAnimeService
	{
		readonly IAnime iAnime;

		public AnimeService(IAnime iAnime)
		{
			this.iAnime = iAnime;
		}

		public List<Anime> GetAllAnimes()
		{
			List<Anime> animes = new();

			try
			{
				List<AnimeDTO> animeDTOs = iAnime.GetAnimes();
				foreach (AnimeDTO animeDTO in animeDTOs)
				{
					animes.Add(new Anime(animeDTO));
				}
			}

			catch (Exception exception)
			{
				throw new Exception("Can't add animes to collection", exception);
			}

			return animes;
		}

		public List<AnimeOverview> GetAnimeById(int animeId)
		{
			List<AnimeOverview> animes = new();

			try
			{
				List<AnimeOverviewDTO> animeOverviewDTOs = iAnime.GetAnimeById(animeId);
				foreach (AnimeOverviewDTO animeOverviewDTO in animeOverviewDTOs)
				{
					animes.Add(new AnimeOverview(animeOverviewDTO));
				}
			}

			catch (Exception exception)
			{
				throw new Exception("Can't add animes to collection", exception);
			}

			return animes;
		}

		public void AddAnimeToList(int animeId)
		{
			iAnime.AddAnimeToList(animeId);
		}
	}
}
