using Listed.BLL.DTOs;
using Listed.BLL.Interfaces;
using MySql.Data.MySqlClient;

namespace Listed.DAL
{
	public class ListDAL : DbCon, IList
	{
		public void DeleteListItem(int listItemId)
		{
			string sqlQuery = "DELETE FROM list WHERE list_item_id = @id";

			using (MySqlCommand sqlCommand = new(sqlQuery, DbConnection))
			{
				sqlCommand.Parameters.AddWithValue("@id", listItemId);
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

		public List<ListDTO> GetListItems()
		{
			List<ListDTO> listItems = new();
			string sqlQuery = "SELECT list_item_id, status, anime_cover_art FROM list INNER JOIN anime ON list.anime_id = anime.anime_id WHERE user_id=@userId;";

			using (MySqlCommand sqlCommand = new(sqlQuery, DbConnection))
			{
				sqlCommand.Parameters.AddWithValue("@userId", 1);
				DbConnection.Open();
				try
				{
					MySqlDataReader reader = sqlCommand.ExecuteReader();

					while (reader.Read())
					{
						listItems.Add(new ListDTO
						{
							ListItemId = Convert.ToInt32(reader["list_item_id"]),
							Status = reader["status"].ToString(),
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
			return listItems;
		}

		public List<ListOverviewDTO> GetListItemsById(int listItemId)
		{
			List<ListOverviewDTO> listItems = new();
			string sqlQuery = "SELECT list_item_id, anime_cover_art, anime_name, episodes_watched, anime_episodes, user_rating, status FROM list INNER JOIN anime ON list.anime_id = anime.anime_id WHERE list_item_id = @listItemId;";

			using (MySqlCommand sqlCommand = new(sqlQuery, DbConnection))
			{
				sqlCommand.Parameters.AddWithValue("@listItemId", listItemId);
				DbConnection.Open();
				try
				{
					MySqlDataReader reader = sqlCommand.ExecuteReader();

					while (reader.Read())
					{
						listItems.Add(new ListOverviewDTO
						{
							ListItemId = Convert.ToInt32(reader["list_item_id"]),
							AnimeCoverArt = (byte[])reader["anime_cover_art"],
							AnimeName = reader["anime_name"].ToString(),
							EpisodesWatched = Convert.ToInt32(reader["episodes_watched"]),
							AnimeEpisodes = Convert.ToInt32(reader["anime_episodes"]),
							UserRating = Convert.ToInt32(reader["user_rating"]),
							Status = reader["status"].ToString(),
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
			return listItems;
		}

		public void UpdateListItem(int listItemId, UpdateListItemDTO updateListItemDTO)
		{
			string sqlQuery = "UPDATE list SET episodes_watched=@animeEpisodes, user_rating=@userRating WHERE list_item_id=@animeId;";

			using (MySqlCommand sqlCommand = new(sqlQuery, DbConnection))
			{
				sqlCommand.Parameters.AddWithValue("@animeId", listItemId);
				sqlCommand.Parameters.AddWithValue("@animeEpisodes", updateListItemDTO.AnimeEpisodes);
				sqlCommand.Parameters.AddWithValue("@animeRating", updateListItemDTO.AnimeRating);
				sqlCommand.Parameters.AddWithValue("@animeStatus", updateListItemDTO.AnimeStatus);
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
	}
}
