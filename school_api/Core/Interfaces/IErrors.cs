

namespace school_api.Core.Interfaces
{
    public interface IErrors
    {
        int StatusCode { get; }
        string Name { get; }
        string Type { get; }
        string Message { get; }
        object? Details { get; }
    }
}