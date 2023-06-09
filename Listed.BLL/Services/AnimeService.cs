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
				List<AnimeDTO> animeDTOs = iAnime.GetAllAnimes();
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

		public AnimeOverview GetAnimeById(int animeId)
		{
			AnimeOverviewDTO animeOverviewDTO = new();

			try
			{
				animeOverviewDTO = iAnime.GetAnimeById(animeId);
			}
			catch (Exception exception)
			{
				throw new Exception("Can't add animes to collection", exception);
			}

			return new AnimeOverview(animeOverviewDTO);
		}

		public void AddAnimeToList(int animeId)
		{
			try
			{
				bool DoesAnimeExists = iAnime.AnimeExistsInList(animeId);

				if (!DoesAnimeExists)
				{
					iAnime.AddAnimeToList(animeId);
				}
				else
				{
					throw new Exception("Anime already exists in list");
				}
			}
			catch (Exception exception)
			{
				throw new Exception("Couldn't add anime to list", exception);
			}
		}
	}
}
