

using school_api.Core.Interfaces;

namespace school_api.Application.Common.Errors
{

    public class UnauthorizedError : Exception, IErrors
    {
        public int StatusCode { get; } = 401;
        public string Name { get; } = typeof(UnauthorizedError).Name;
        public string Type { get; } = "";
        public object? Details { get; }

        public UnauthorizedError(string message) : base(message){ }
    }
}