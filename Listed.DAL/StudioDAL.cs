using Listed.BLL.DTOs;
using Listed.BLL.Interfaces;
using MySql.Data.MySqlClient;

namespace Listed.DAL
{
	public class StudioDAL : DbCon, IStudio
	{
		public List<StudioOverviewDTO> GetStudioById(int studioId)
		{
			List<StudioOverviewDTO> studioOverviews = new();
			string sqlQuery = "SELECT studio_name, anime_id, anime_cover_art from studio INNER JOIN anime ON studio.studio_id = anime.studio_id WHERE studio.studio_id = @studioId;";

			using (MySqlCommand sqlCommand = new(sqlQuery, DbConnection))
			{
				sqlCommand.Parameters.AddWithValue("@studioId", studioId);
				DbConnection.Open();
				try
				{
					MySqlDataReader reader = sqlCommand.ExecuteReader();

					while (reader.Read())
					{
						studioOverviews.Add(new StudioOverviewDTO
						{
							StudioName = reader["studio_name"].ToString(),
							AnimeId = Convert.ToInt32(reader["anime_id"]),
							AnimeCoverArt = (byte[])reader["anime_cover_art"],
						});
					}

					reader.Close();
				}
				catch (Exception exception)
				{
					throw new Exception("Can't connect to database, contact administrator", exception);
				}
			}
			return studioOverviews;
		}

		public List<StudioDTO> GetStudios()
		{
			List<StudioDTO> studios = new();
			string sqlQuery = "SELECT studio_id, studio_name FROM studio;";

			using (MySqlCommand sqlCommand = new(sqlQuery, DbConnection))
			{
				DbConnection.Open();
				try
				{
					MySqlDataReader reader = sqlCommand.ExecuteReader();

					while (reader.Read())
					{
						studios.Add(new StudioDTO
						{
							StudioId = Convert.ToInt32(reader["studio_id"]),
							StudioName = reader["studio_name"].ToString()
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
			return studios;
		}
	}
}
