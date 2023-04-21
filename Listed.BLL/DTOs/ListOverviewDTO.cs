namespace Listed.BLL.DTOs
{
	public class ListOverviewDTO
	{
		public int ListItemId { get; set; }
		public byte[] AnimeCoverArt { get; set; } = Array.Empty<byte>();
		public string AnimeName { get; set; } = string.Empty;
		public int? EpisodesWatched { get; set; }
		public int AnimeEpisodes { get; set; }
		public int? UserRating { get; set; }
		public string Status { get; set; } = string.Empty;
	}
}
