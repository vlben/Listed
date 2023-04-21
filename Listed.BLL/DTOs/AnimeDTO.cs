namespace Listed.BLL.DTOs
{
    public class AnimeDTO
    {
        public int AnimeId { get; set; }
        public byte[] AnimeCoverArt { get; set; } = Array.Empty<byte>();
    }
}
