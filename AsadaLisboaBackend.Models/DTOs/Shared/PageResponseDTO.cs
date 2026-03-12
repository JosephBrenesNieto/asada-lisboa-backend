namespace AsadaLisboaBackend.Models.DTOs.Shared
{
    public class PageResponseDTO<T>
    {
        public int Total { get; set; }
        public List<T> Data { get; set; } = new List<T>();
    }
}
