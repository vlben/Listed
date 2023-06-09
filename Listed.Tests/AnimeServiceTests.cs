using Listed.BLL.Interfaces;
using Listed.BLL.Services;
using Listed.Tests.Classes;

namespace Listed.Tests
{
	[TestClass]
	public class AnimeServiceTests
	{
		[TestMethod]
		public void AddAnimeToList_AddAnime_AnimeAddedToList()
		{
			//Arrange
			int animeId = 2;
			IAnime iAnime = new AnimeListDAL();
			AnimeService animeService = new(iAnime);

			//Act
			animeService.AddAnimeToList(animeId);
			var anime = animeService.GetAnimeById(animeId);

			//Assert
			Assert.AreEqual(anime.AnimeId, animeId);
		}

		[TestMethod]
		public void AddAnimeToList_AddAnime_AnimeFailedToAdd()
		{
			//Arrange
			int animeId = 1;
			IAnime iAnime = new AnimeListDAL();
			AnimeService animeService = new(iAnime);

			//Act & Assert
			Assert.ThrowsException<Exception>(() => animeService.AddAnimeToList(animeId));
		}
	}
}
