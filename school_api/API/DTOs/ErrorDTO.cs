

namespace school_api.API.DTOs
{
    public class ErrorDTO
    {
        public int statusCode { get; set; }
        public string? path { get; set; }
        public string? error { get; set; }
        public string? message { get; set; }
        public object? details { get; set; }
    }
}