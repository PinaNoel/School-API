

namespace school_api.API.DTOs
{
    public class ReplyDTO
    {
        public int statusCode { get; set; }
        public string? path { get; set; }
        public string? message { get; set; }
        public object? data { get; set; }
    }
}