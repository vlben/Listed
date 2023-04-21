﻿using Listed.BLL.Classes;

namespace Listed.BLL.Interfaces
{
	public interface IAnimeService
	{
		List<Anime> GetAllAnimes();
		List<AnimeOverview> GetAnimeById(int animeId);
		public void AddAnimeToList(int animeId);
	}
}