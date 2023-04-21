namespace Listed.BLL.DTOs
{
    public class StudioOverviewDTO
    {
        public string StudioName { get; set; } = string.Empty;
        public int AnimeId { get; set; }
        public byte[] AnimeCoverArt { get; set; } = Array.Empty<byte>();
    }
}
