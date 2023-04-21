using Listed.BLL.DTOs;
using Listed.BLL.Interfaces;
using MySql.Data.MySqlClient;

namespace Listed.DAL
{
	public class AnimeDAL : DbCon, IAnime
	{
		public void AddAnimeToList(int animeId)
		{
			string sqlQuery = "INSERT INTO list (user_id, anime_id) VALUES (@userId, @animeId);";

			using (MySqlCommand sqlCommand = new(sqlQuery, DbConnection))
			{
				sqlCommand.Parameters.AddWithValue("@userId", 1);
				sqlCommand.Parameters.AddWithValue("@animeId", animeId);
				DbConnection.Open();
				try
				{
					sqlCommand.ExecuteScalar();
				}

				catch (MySqlException exception)
				{
					throw new Exception("Can't connect to database, contact administrator", exception);
				}

				finally
				{
					DbConnection.Close();
				}
			}
		}

		public List<AnimeOverviewDTO> GetAnimeById(int animeId)
		{
			List<AnimeOverviewDTO> animeOverviews = new();
			string sqlQuery = "SELECT anime_id, anime_name, anime_episodes, anime_cover_art, anime.studio_id, studio_name FROM anime INNER JOIN studio ON anime.studio_id = studio.studio_id WHERE anime_id = @animeId;";

			using (MySqlCommand sqlCommand = new(sqlQuery, DbConnection))
			{
				sqlCommand.Parameters.AddWithValue("@animeId", animeId);
				DbConnection.Open();
				try
				{
					MySqlDataReader reader = sqlCommand.ExecuteReader();

					while (reader.Read())
					{
						animeOverviews.Add(new AnimeOverviewDTO
						{
							AnimeId = Convert.ToInt32(reader["anime_id"]),
							AnimeEpisodes = Convert.ToInt32(reader["anime_episodes"]),
							StudioId = Convert.ToInt32(reader["studio_id"]),
							StudioName = reader["studio_name"].ToString(),
							AnimeName = reader["anime_name"].ToString(),
							AnimeCoverArt = (byte[])reader["anime_cover_art"],
						});
					}

					reader.Close();
				}

				catch (MySqlException exception)
				{
					throw new Exception("Can't connect to database, contact administrator", exception);
				}

				finally
				{
					DbConnection.Close();
				}
			}
			return animeOverviews;
		}

		public List<AnimeDTO> GetAnimes()
		{
			List<AnimeDTO> animes = new();
			string sqlQuery = "SELECT anime_id, anime_cover_art FROM anime;";

			using (MySqlCommand sqlCommand = new(sqlQuery, DbConnection))
			{
				DbConnection.Open();
				try
				{
					MySqlDataReader reader = sqlCommand.ExecuteReader();

					while (reader.Read())
					{
						animes.Add(new AnimeDTO
						{
							AnimeId = Convert.ToInt32(reader["anime_id"]),
							AnimeCoverArt = (byte[])reader["anime_cover_art"],
						});
					}

					reader.Close();
				}

				catch (MySqlException exception)
				{
					throw new Exception("Can't connect to database, contact administrator", exception);
				}

				finally
				{
					DbConnection.Close();
				}
			}
			return animes;
		}
	}
}
