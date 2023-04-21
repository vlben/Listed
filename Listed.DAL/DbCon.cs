using MySql.Data.MySqlClient;

namespace Listed.DAL
{
	public class DbCon
	{
		private readonly string dbConString = "Server=localhost;Port=3306;Database=listed_db;Uid=root;Pwd=;";

		private readonly MySqlConnection dbConn;

		public MySqlConnection DbConnection
		{
			get { return dbConn; }
		}

		public DbCon()
		{
			if (dbConString is null)
			{
				throw new Exception("no connection string");
			}

			dbConn = new MySqlConnection(dbConString);
		}
	}
}
