namespace Listed.BLL.DTOs
{
	public class AnimeOverviewDTO
	{
		public int AnimeId { get; set; }
		public string AnimeName { get; set; } = string.Empty;
		public int StudioId { get; set; }
		public string StudioName { get; set; } = string.Empty;
		public int AnimeEpisodes { get; set; }
		public byte[] AnimeCoverArt { get; set; } = Array.Empty<byte>();
	}
}
