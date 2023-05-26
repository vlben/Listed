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
					sqlCommand.ExecuteNonQuery();
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

		public bool AnimeExistsInList(int animeId)
		{
			string sqlQuery = "SELECT list_item_id FROM listed_db.list WHERE anime_id = @animeId && user_id = @userId;";

			using (MySqlCommand sqlCommand = new(sqlQuery, DbConnection))
			{
				sqlCommand.Parameters.AddWithValue("@userId", 1);
				sqlCommand.Parameters.AddWithValue("@animeId", animeId);
				DbConnection.Open();
				try
				{
					int DoesAnimeExist = Convert.ToInt32(sqlCommand.ExecuteScalar());

					if (DoesAnimeExist == 0)
					{
						return false;
					}

					else
					{
						return true;
					}
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

		public AnimeOverviewDTO GetAnimeById(int animeId)
		{
			AnimeOverviewDTO animeOverviewDTO = new();
			string sqlQuery = "SELECT anime_id, anime_name, anime_episodes, anime_cover_art, anime.studio_id, studio_name FROM anime INNER JOIN studio ON anime.studio_id = studio.studio_id WHERE anime_id = @animeId;";

			using (MySqlCommand sqlCommand = new(sqlQuery, DbConnection))
			{
				sqlCommand.Parameters.AddWithValue("@animeId", animeId);
				DbConnection.Open();
				try
				{
					MySqlDataReader reader = sqlCommand.ExecuteReader();

					if (reader.Read())
					{
						animeOverviewDTO = new AnimeOverviewDTO
						{
							AnimeId = Convert.ToInt32(reader["anime_id"]),
							AnimeEpisodes = Convert.ToInt32(reader["anime_episodes"]),
							StudioId = Convert.ToInt32(reader["studio_id"]),
							StudioName = reader["studio_name"].ToString(),
							AnimeName = reader["anime_name"].ToString(),
							AnimeCoverArt = (byte[])reader["anime_cover_art"],
						};
					}

					reader.Close();
				}

				catch (MySqlException exception)
				{
					//TODO Custom exception, en logging
					throw new Exception("Can't connect to database, contact administrator", exception);
				}

				finally
				{
					DbConnection.Close();
				}
			}
			return animeOverviewDTO;
		}

		public List<AnimeDTO> GetAllAnimes()
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
