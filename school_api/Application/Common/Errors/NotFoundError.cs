

using school_api.Core.Interfaces;

namespace school_api.Application.Common.Errors
{

    public class NotFoundError : Exception, IErrors
    {
        public int StatusCode { get; } = 404;
        public string Name { get; } = typeof(NotFoundError).Name;
        public string Type { get; } = "";
        public object? Details { get; }

        public NotFoundError(string message) : base(message){ }
    }
}