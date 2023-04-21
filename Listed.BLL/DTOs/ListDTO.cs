namespace Listed.BLL.DTOs
{
    public class ListDTO
    {
        public int ListItemId { get; set; }
        public string Status { get; set; } = string.Empty;
        public byte[] AnimeCoverArt { get; set; } = Array.Empty<byte>();
    }
}
